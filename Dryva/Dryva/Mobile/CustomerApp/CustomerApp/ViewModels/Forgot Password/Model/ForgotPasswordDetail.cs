using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.ViewModels.Forgot_Password
{
    public class ForgotPasswordDetail : ViewModelBase
    {
        private string _phoneNUmber;
        public string PhoneNumber
        {
            get { return _phoneNUmber; }
            set { _phoneNUmber = value; this.RaisePropertyChanged(); }
        }

        
        private int? _otp;
        public int? OTP
        {
            get { return _otp; }
            set { _otp = value; this.RaisePropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; this.RaisePropertyChanged(); }
        }


        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; this.RaisePropertyChanged(); }
        }

    }
}
