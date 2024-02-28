using CustomerApp.Enum;
using CustomerApp.Helpers;
using CustomerApp.ViewModels.Forgot_Password;
using CustomerApp.Views;
using Dryva.Utilities.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class ForgotPasswordViewModel : ViewModelBase
    {
        private ContentView newContentView;
        public ContentView NewContentView
        {
            get { return newContentView; }
            set { newContentView = value; this.RaisePropertyChanged(); }
        }

        public ForgotPasswordDetail Model { get; set; } = new ForgotPasswordDetail();
        public ICommand ResetPasswordCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ICommand FinalSubmitCommand { get; set; }
        public INavigation Navigation { get; }

        private string resendingOTPText;
        public string ResendingOTPText
        {
            get { return resendingOTPText; }
            set { resendingOTPText = value; this.RaisePropertyChanged(); }
        }

        private OTPMOdel newOTPModel;
        public ForgotPasswordViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.ResetPasswordCommand = new Command(this.ResetPasswordAction);
            this.SubmitCommand = new Command(this.SubmitAction);
            this.FinalSubmitCommand = new Command(this.FinalSubmitAction);

            this.LoadDefault();
        }

        public async Task ChangePhoneNumber()
        {

        }

        public async Task ReSendOTP()
        {
            this.SendOTP_SMS();
            this.ResendingOTPText = "New OTP sent.";
            this.Model.OTP = null;

            await Task.Delay(500);

            this.ResendingOTPText = "";
        }


        private OTPMOdel GenerateOTP()
        {
            int num = new Random().Next(4, 6);
            return OTPUtil.GenerateOTP(num);
        }

        private void SendOTP_SMS()
        {
            this.newOTPModel = this.GenerateOTP();
            // Use the SMS gateway to send OTP to customer phone number
            string msg = $"Please use the OTP code {this.newOTPModel.OTP} to complete this process, It expires {this.newOTPModel.ExpiryDateText}. ";
            int? feedbackResult = App.Services.SMSService.SendSMS(msg, this.Model.PhoneNumber);
        }

        private async void LoadDefault()
        {
            await Task.Run(() => Xamarin.Forms.Device.BeginInvokeOnMainThread(() => this.NewContentView = new ForgotPasswordView1()));
        }
        private async void ResetPasswordAction(object obj)
        {
            if (!await Validator.ValidatePhoneNumber(this.Model.PhoneNumber))
                return;

            var item = await App.Services.Customer.GetRegistrationByPhoneNumberAsync(this.Model.PhoneNumber);
            if (item.Data != null)
            {
                this.SendOTP_SMS();
                await Task.Run(() => Xamarin.Forms.Device.BeginInvokeOnMainThread(() => this.NewContentView = new ForgotPasswordView2()));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "Phone number has not been registered.", "Ok");
            }
        }
        private async void SubmitAction(object obj)
        {

            if (this.newOTPModel.OTP != this.Model.OTP.Value)
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "Wrong OTP.", "Ok");
                return;
            }
            if (this.newOTPModel.ExpiryDate < DateTime.Now)
            {
                await App.Current.MainPage.DisplayAlert("Expiration", "OTP has expired.", "Ok");
                return;
            }

            await Task.Run(() => Xamarin.Forms.Device.BeginInvokeOnMainThread(() => this.NewContentView = new ForgotPasswordView3()));
        }
        private async void FinalSubmitAction(object obj)
        {
            if (this.Model.Password != this.Model.ConfirmPassword)
            {
                await App.Current.MainPage.DisplayAlert("Mismatch", "Password mismatch.", "Ok");
                return;
            }

            var customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            customerInfo.Password = this.Model.Password;
            await App.Services.Customer.SaveCustomerDetail_Local(customerInfo);

            await Navigation.DisplayMessage(ButtonTypeEnum.Login, IconTypeEnum.Success, "Forgot Password", "Success!", "Password Changed");
        }
    }
}
