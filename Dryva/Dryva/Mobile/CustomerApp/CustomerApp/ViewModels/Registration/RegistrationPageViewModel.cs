using CustomerApp.DTOs.Customer;
using CustomerApp.Enum;
using CustomerApp.Helpers;
using CustomerApp.Models;
using CustomerApp.ViewModels.Registration.Models;
using CustomerApp.Views;
using Plugin.Connectivity;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.ViewModels.Registration
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        public Image imgPixControl { get; set; }
        public RegistrationModel1 Model1 { get; } = new RegistrationModel1();
        public RegistrationModel2 Model2 { get; } = new RegistrationModel2();
        public RegistrationModel3 Model3 { get; } = new RegistrationModel3();


        public ICommand NextCommand { get; }

        public ICommand Next2Command { get; }
        public ICommand SubmitCommand { get; }

        public INavigation Navigation { get; }



        static RegistrationPageViewModel _instance;
        public static RegistrationPageViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RegistrationPageViewModel();
                return _instance;
            }
        }

        private RegistrationPageViewModel()
        {
            this.Navigation = App.Current.MainPage.Navigation;
            this.NextCommand = new Command(this.NextAction);
            this.Next2Command = new Command(this.Next2Action);
            this.SubmitCommand = new Command(this.SubmitAction);
        }


        private async void NextAction()
        {
            this.Busy();
            if (await Model1.VerifyInformation() == true)
            {
                var savedModel = await App.Services.Customer.GetRegistrationByPhoneNumberAsync(this.Model1.PhoneNumber);
                if (savedModel.Data != null && savedModel.IsSuccess)
                {
                    this.NotBusy();
                    await App.Current.MainPage.DisplayAlert("Register", "The phone number has already been registered, Proceed to login page.", "Ok");
                    await Navigation.PushAsync(new LoginPage(), true);
                    return;
                }
                Model3.SetMessage(Model1.PhoneNumber);

                this.NotBusy();
                await Navigation.PushAsync(new RegistrationPage2(), true);
            }
            this.NotBusy();
        }
        private async void Next2Action()
        {
            this.Busy();
            await Model3.ReSendOTP();
            this.NotBusy();
            await Navigation.PushAsync(new RegistrationPage3(), true);
        }

        private async Task SaveLocalDBInformation(Guid customerId)
        {
            var customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            if (customerInfo == null)
                customerInfo = new CustomerInfo();

            customerInfo.PhoneNumber = this.Model1.PhoneNumber;
            customerInfo.Email = this.Model1.Email;
            customerInfo.FirstName = this.Model1.FirstName;
            customerInfo.LastName = this.Model1.LastName;
            customerInfo.Photo = this.Model2.Photograph;
            customerInfo.Password = Model1.Password;
            customerInfo.CustomerId = customerId;

            await App.Services.Customer.SaveCustomerDetail_Local(customerInfo);
        }
        private async void SubmitAction()
        {
            this.Busy();

            if (await Model3.ValidateOTP())
            {
                // Save model.
                var service = App.Services.Customer;

                if (!await NetworkUtil.ValidateNetwork())
                {
                    this.NotBusy();
                    return;
                }

                var savedModel = await service.SaveRegistrationAsync(Model1.GetRegistrationDTO());
                if (savedModel.Data != null && savedModel.IsSuccess)
                {
                    await service.UpdateCustomerAsync(new PersonalDataDTO() { BirthDate = Model2.BirthDate, Id = savedModel.Data.Id });
                    await service.UpdateCustomerAsync(new BioDataDTO() { Photograph = Model2.Photograph, Id = savedModel.Data.Id });

                    await SaveLocalDBInformation(savedModel.Data.Id);

                    var contactDto = new ContactDataDTO()
                    {
                        Email = Model1.Email,
                        ResidentialCity = Model2.City,
                        ResidentialState = Model2.State,
                        Id = savedModel.Data.Id
                    };
                    await service.UpdateCustomerAsync(contactDto);
                }
                else
                {
                    this.NotBusy();
                    await App.Current.MainPage.DisplayAlert("Invalid", "Save not successful.", "Ok");
                }

                this.NotBusy();

                await Navigation.DisplayMessage(ButtonTypeEnum.Login, IconTypeEnum.Success, "Registration", "Congratulation!", "Registration Successful!", "Thanks for coming onboard with Dryva");
            }
            else
            {
                this.NotBusy();
                await App.Current.MainPage.DisplayAlert("Invalid", "Wrong OTP.", "Ok");
            }

            this.NotBusy();
        }

    }
}

