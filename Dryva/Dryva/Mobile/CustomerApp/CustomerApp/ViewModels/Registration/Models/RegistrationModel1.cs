using CustomerApp.DTOs.Customer;
using CustomerApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.ViewModels.Registration.Models
{
    public class RegistrationModel1 : ViewModelBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; this.RaisePropertyChanged(); }
        }

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

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; this.RaisePropertyChanged(); }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; this.RaisePropertyChanged(); }
        }


        public async Task<bool> VerifyInformation()
        {
            var page = App.Current.MainPage;
            if (!await Validator.ValidateFirstName(this.FirstName))
                return false;
            if (!await Validator.ValidateLastName(this.LastName))
                return false;
            if (!await Validator.ValidatePhoneNumber(this.PhoneNumber))
                return false;
            if (!await Validator.ValidateEmail(this.Email))
                return false;

            //if (string.IsNullOrEmpty(this.FirstName))
            //{
            //    await page.DisplayAlert("Incomplete", "First Name should be entered!.", "Ok");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(this.LastName))
            //{
            //    await page.DisplayAlert("Incomplete", "Last Name should be entered!.", "Ok");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(this.PhoneNumber))
            //{
            //    await page.DisplayAlert("Incomplete", "Phone Number should be entered!.", "Ok");
            //    return false;
            //}
            if (this.Password != this.ConfirmPassword)
            {
                await page.DisplayAlert("Mismatch", "Password mismatch.", "Ok");
                return false;
            }
            return true;
        }

        public RegistrationDTO GetRegistrationDTO()
        {
            var model = new RegistrationDTO();
            model.FirstName = this.FirstName;
            model.Surname = this.LastName;
            model.PhoneNumber = this.PhoneNumber;
            model.Title = this.Title;
            return model;
        }
    }
}
