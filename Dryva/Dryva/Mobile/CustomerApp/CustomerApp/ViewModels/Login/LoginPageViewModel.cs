using CustomerApp.DTOs.Customer;
using CustomerApp.Helpers;
using CustomerApp.Models;
using CustomerApp.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        string generatedPasswordKey = "GeneratedPasswordCode";
        public INavigation Navigation { get; }
        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public CustomerInfo Model { get; private set; } = new CustomerInfo();


        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.LoginCommand = new Command(this.LoginAction);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordAction);

            this.Model = App.Services.Customer.GetCustomerDetail_Local();
        }

        private async void LoginAction()
        {
            this.Busy();
            CustomerInfo loginInfo = App.Services.Customer.GetCustomerDetail_Local();

            if (loginInfo != null && loginInfo.Csn.HasValue)
            {
                this.LoginOfflineMode(loginInfo);
                this.NotBusy();
                return;
            }

            if (NetworkUtil.IsConnected())
            {
                CustomerDataDTO customerDataDTO = null;
                if (App.Current.Properties.ContainsKey(NameConstant.CustomerOnlineData))
                {
                    customerDataDTO = (CustomerDataDTO)App.Current.Properties[NameConstant.CustomerOnlineData];
                }
                else
                {
                    var item = await App.Services.Customer.GetCustomerByPhoneNumberAsync(this.Model.PhoneNumber);
                    customerDataDTO = item.Data;
                }
                //var item = await App.Services.Customer.GetCustomerByPhoneNumberAsync(this.Model.PhoneNumber);

                //It is used when a registered customer need to login with the phone for the first time.
                if (customerDataDTO != null)
                {
                    if (loginInfo != null)
                    {
                        loginInfo.SetData(customerDataDTO);
                        this.LoginOfflineMode(loginInfo);
                        this.NotBusy();
                        return;
                    }

                    //if (item.Data != null)
                    //{
                    if (App.Current.Properties.ContainsKey(generatedPasswordKey))
                    {
                        if (this.Model.Password == App.Current.Properties[generatedPasswordKey].ToString())
                        {
                            this.Model.CustomerId = customerDataDTO.Id;
                            this.Model.FirstName = customerDataDTO.FirstName;
                            this.Model.LastName = customerDataDTO.Surname;
                            this.Model.Csn = customerDataDTO.Csn;

                            App.Current.Properties.Remove(generatedPasswordKey);
                            await App.Services.Customer.SaveCustomerDetail_Local(this.Model);

                            this.NotBusy();
                            App.Current.MainPage = new NavigationPage(new MasterMenu());
                        }
                        else
                        { // Customer password invalid.
                            await App.Current.MainPage.DisplayAlert("Invalid Credentials", "Credentials supplied not valid!.", "Ok");

                            this.NotBusy();
                            return;
                        }

                        this.NotBusy();
                    }
                    else
                    {
                        // Generate new password for already registered customer for the first time of phone usage.
                        if (!App.Current.Properties.ContainsKey(NameConstant.CustomerOnlineData))
                        {
                            App.Current.Properties.Add(NameConstant.CustomerOnlineData, customerDataDTO);
                        }
                        this.GeneratePassword();

                        this.NotBusy();
                        return;
                    }

                    this.NotBusy();
                }
                else
                {
                    // Customer Data not found.

                    this.NotBusy();
                    await App.Current.MainPage.DisplayAlert("Invalid Credentials", "Credentials supplied not valid!.", "Ok");
                    return;
                }

                this.NotBusy();
                //}
                //else
                //{
                //    this.NotBusy();
                //    await App.Current.MainPage.DisplayAlert("Invalid Credentials", "Credentials supplied not valid!.", "Ok");
                //    return;
                //}

                //this.NotBusy();
            }
            else
            {
                this.LoginOfflineMode(loginInfo);
            }

            this.NotBusy();
        }
        private async void LoginOfflineMode(CustomerInfo loginInfo)
        {
            // Login in offline mode
            if (loginInfo != null)
            {
                if (loginInfo.PhoneNumber == this.Model.PhoneNumber && loginInfo.Password == this.Model.Password)
                {
                    await App.Services.Customer.SaveCustomerDetail_Local(this.Model);

                    this.NotBusy();
                    App.Current.MainPage = new NavigationPage(new MasterMenu());
                }
                else
                {
                    this.NotBusy();
                    await App.Current.MainPage.DisplayAlert("Invalid Credentials", "Credentials supplied not valid!.", "Ok");
                }
            }
            else
            {
                // There is network failure.
                await NetworkUtil.ValidateNetwork();
            }
        }
        private async void GeneratePassword()
        {
            string newPassword = OTPUtil.GeneratePassword(7).ToString();
            string msg = $"Please use the password code {newPassword} to login now. ";
            int? feedbackResult = App.Services.SMSService.SendSMS(msg, this.Model.PhoneNumber);

            App.Current.Properties[generatedPasswordKey] = newPassword;
            await App.Current.MainPage.DisplayAlert("New Login Detail", "A new password has been sent to your phone.", "Ok");

        }
        public async void ForgotPasswordAction()
        {
            await Navigation.PushAsync(new ForgotPasswordPage(), true);
        }


    }
}
