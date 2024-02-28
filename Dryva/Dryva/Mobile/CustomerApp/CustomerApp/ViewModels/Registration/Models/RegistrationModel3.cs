using CustomerApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerApp.ViewModels.Registration.Models
{
    public class RegistrationModel3 : ViewModelBase
    {
        private OTPMOdel newOTPModel;
        private string msg = "We are unable to auto-verify your mobile number. "
                    + "please enter the code tested to ";

        private int? oTP;
        public int? OTP
        {
            get { return oTP; }
            set { oTP = value; this.RaisePropertyChanged(); }
        }

        private string resendingOTPText;
        public string ResendingOTPText
        {
            get { return resendingOTPText; }
            set { resendingOTPText = value; this.RaisePropertyChanged(); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            private set { message = value; this.RaisePropertyChanged(); }
        }

        public void SetMessage(string phoneNumber)
        {
            this.Message = $"{this.msg}{phoneNumber}";
        }

        public async Task ReSendOTP()
        {
            this.SendOTP_SMS();
            this.ResendingOTPText = "New OTP sent.";
            this.OTP = null;

            await Task.Delay(500);

            this.ResendingOTPText = "";
        }

        public async Task<bool> ValidateOTP()
        {
            if (this.newOTPModel.OTP != this.OTP.Value)
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "Wrong OTP.", "Ok");
                return false;
            }
            if (this.newOTPModel.ExpiryDate < DateTime.Now)
            {
                await App.Current.MainPage.DisplayAlert("Expiration", "OTP has expired.", "Ok");
                return false;
            }
            return true;
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

            string phoneNumber = RegistrationPageViewModel.Instance.Model1.PhoneNumber;

            string msg = $"Please use the OTP code {this.newOTPModel} to complete this process, It expires {this.newOTPModel.ExpiryDate}. ";
            int? feedbackResult = App.Services.SMSService.SendSMS(msg, phoneNumber);
        }
    }
}
