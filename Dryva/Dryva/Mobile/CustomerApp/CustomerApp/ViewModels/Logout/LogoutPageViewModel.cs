using CustomerApp.Models;
using CustomerApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class LogoutPageViewModel : ViewModelBase
    {
        public INavigation Navigation { get; }
        public ICommand LogoutCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public LogoutPageViewModel()
        {
            this.Navigation = App.Current.MainPage.Navigation;
            this.LogoutCommand = new Command(this.LogoutAction);
            this.CancelCommand = new Command(this.CancelAction);
        }

        private async void LogoutAction()
        {
            var loginModel = App.Services.Customer.GetCustomerDetail_Local();
            loginModel.RememberMe = false;
            await App.Services.Customer.SaveCustomerDetail_Local(loginModel);

            await Navigation.PopModalAsync(true);
            await Navigation.PushAsync(new LoginPage(), true);
        }
        private async void CancelAction()
        {
            await Navigation.PopModalAsync(true);
        }
    }
}
