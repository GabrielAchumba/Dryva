using CustomerApp.DTOs.Customer;
using CustomerApp.Enum;
using CustomerApp.Helpers;
using CustomerApp.Models;
using CustomerApp.ViewModels.Registration.Models;
using CustomerApp.Views;
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
    public class EditProfilePageViewModel : ViewModelBase
    {
        
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; this.RaisePropertyChanged(); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; this.RaisePropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; this.RaisePropertyChanged(); }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; this.RaisePropertyChanged(); }
        }
        public Guid CustomerId { get; set; }
        private byte[] photograph;
        public byte[] Photograph
        {
            get { return photograph; }
            set { photograph = value; this.RaisePropertyChanged(); }
        }

        private byte[] newUploadPhotograph;
        public byte[] NewUploadPhotograph
        {
            get { return newUploadPhotograph; }
            set { newUploadPhotograph = value; this.RaisePropertyChanged(); }
        }
        public ICommand NextCommand { get; }
        public ICommand SubmitCommand { get; }

        public INavigation Navigation { get; }

        private bool enableUploadCommand = true;
        public bool EnableUploadCommand
        {
            get { return enableUploadCommand; }
            set { enableUploadCommand = value; this.RaisePropertyChanged(); }
        }

        static EditProfilePageViewModel _instance;
        public static EditProfilePageViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EditProfilePageViewModel();

                //if (_instance != null)
                //    _instance.SetCustomerInformation();

                return _instance;
            }
        }

        private CustomerDataDTO CustomerData;
        private EditProfilePageViewModel()
        {
            this.Navigation = App.Current.MainPage.Navigation;
            this.SubmitCommand = new Command(this.SubmitAction);
            this.NextCommand = new Command(this.NextAction);
            this.CustomerData = new CustomerDataDTO();

            //Task.Run(async () =>
            //{
            //    await SetCustomerInformation();
            //    await SetInformation();
            //});
        }

        public void SetInformation()
        {
            var loginInfo = App.Services.Customer.GetCustomerDetail_Local();
            this.CustomerId = loginInfo.Id;
            this.FirstName = loginInfo.FirstName;
            this.LastName = loginInfo.LastName;
            this.Email = loginInfo.Email;
            this.PhoneNumber = loginInfo.PhoneNumber;
            this.Photograph = loginInfo.Photo;
        }
        public void SetCustomerInformation()
        {
            this.Busy();

            var loginInfo = App.Services.Customer.GetCustomerDetail_Local();
            this.CustomerData = (CustomerDataDTO)App.Current.Properties[NameConstant.CustomerOnlineData];

            this.NotBusy();
        }
        private async Task<bool> VerifyInformation()
        {
            if (!await Validator.ValidateFirstName(this.FirstName))
                return false;
            if (!await Validator.ValidateLastName(this.LastName))
                return false;
            if (!await Validator.ValidatePhoneNumber(this.PhoneNumber))
                return false;
            if (!await Validator.ValidateEmail(this.Email))
                return false;

            return true;
        }

        public RegistrationDTO GetRegistrationDTO()
        {
            var model = new RegistrationDTO();
            model.FirstName = this.FirstName;
            model.Surname = this.LastName;
            model.PhoneNumber = this.PhoneNumber;
            model.Id = this.CustomerId;
            return model;
        }

        private async Task SaveLocalDBInformation()
        {
            var customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            customerInfo.PhoneNumber = this.PhoneNumber;
            customerInfo.Email = this.Email;
            customerInfo.FirstName = this.FirstName;
            customerInfo.LastName = this.LastName;
            customerInfo.Photo = this.Photograph;
            customerInfo.Csn = this.CustomerData.Csn;

            await App.Services.Customer.SaveCustomerDetail_Local(customerInfo);
        }
        private async Task SaveContactDetail()
        {
            var model = new ContactDataDTO();
            model.Email = this.Email;
            model.ResidentialCity = this.CustomerData.ResidentialCity;
            model.ResidentialState = this.CustomerData.ResidentialState;
            model.Id = this.CustomerData.Id;
            await App.Services.Customer.UpdateCustomerAsync(model);
        }
        private async Task SaveBioData()
        {
            var model = new BioDataDTO();
            model.Photograph = this.Photograph;
            model.Id = this.CustomerData.Id;
            await App.Services.Customer.UpdateCustomerAsync(model);
        }
        private async Task SaveRegistrationData()
        {
            var model = new RegistrationDTO();
            model.Id = this.CustomerData.Id;
            model.PhoneNumber = this.PhoneNumber;
            model.FirstName = this.FirstName;
            model.Surname = this.LastName;
            model.Title = this.CustomerData.Title;
            model.Gender = this.CustomerData.Gender;
            model.Csn = this.CustomerData.Csn;
            await App.Services.Customer.SaveRegistrationAsync(model);
        }


        private async void NextAction()
        {
            this.Busy();
            if (await this.VerifyInformation())
            {
                if (this.PhoneNumber != this.CustomerData.PhoneNumber)
                {
                    var item = await App.Services.Customer.GetRegistrationByPhoneNumberAsync(this.PhoneNumber);
                    if (item.Data != null)
                    {
                        this.NotBusy();
                        await App.Current.MainPage.DisplayAlert("Invalid", "Phone Number already exist!.", "Ok");
                        return;
                    }
                }
                this.NotBusy();
                await Navigation.PushAsync(new EditProfilePage2(), true);
            }
        }

        private async void SubmitAction()
        {
            if (!await NetworkUtil.ValidateNetwork())
            {
                return;
            }

            this.Busy();

            if (this.NewUploadPhotograph != null)
            {
                this.Photograph = this.NewUploadPhotograph;
            }

            await this.SaveLocalDBInformation();
            await this.SaveContactDetail();
            await this.SaveBioData();
            await this.SaveRegistrationData();

            //Save customer data from server on the cache
            var customerInfo = await App.Services.Customer.GetCustomerByPhoneNumberAsync(this.PhoneNumber);
            if(customerInfo.IsSuccess && customerInfo.Data != null)
            {
                App.Current.Properties.Add(NameConstant.CustomerOnlineData, customerInfo.Data);
            }

            this.NotBusy();
            await Navigation.DisplayMessage(ButtonTypeEnum.Home, IconTypeEnum.Success, "Edit Profile", "Success!", "Profile Saved!");

        }

    }
}

