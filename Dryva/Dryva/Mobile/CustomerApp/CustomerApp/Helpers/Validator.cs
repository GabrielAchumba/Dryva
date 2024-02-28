using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerApp.Helpers
{
    public class Validator
    {
        public static async Task<bool> ValidateEmail(string email)
        {
            //string pattern= "^(?(")(".+?(?<!\\)"@)| (([0 - 9a - z]((\.(? !\.)) |[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            string pattern = "^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$";
            var regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "Email adrress is invalid!.", "Ok");
                return false;
            }
            return true;
        }

        public static async Task<bool> ValidateFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                await App.Current.MainPage.DisplayAlert("Incomplete", "First Name should be entered!.", "Ok");
                return false;
            }
            return true;
        }
        public static async Task<bool> ValidateLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                await App.Current.MainPage.DisplayAlert("Incomplete", "Last Name should be entered!.", "Ok");
                return false;
            }
            return true;
        }
        public static async Task<bool> ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || (!phoneNumber.StartsWith("0") || phoneNumber.Length != 11))
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "Phone Number should be entered!.", "Ok");
                return false;
            }
            return true;
        }
        
    }
}
