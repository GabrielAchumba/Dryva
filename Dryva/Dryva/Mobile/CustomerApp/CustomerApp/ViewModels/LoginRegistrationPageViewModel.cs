using CustomerApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class LoginRegistrationPageViewModel : ViewModelBase
    {
        private INavigation Navigation { get; }
        public ICommand GoToLoginPageCommand { get; }
        public ICommand RegisterPageCommand { get; }
        public string WelcomeText { get; set; } = "Uyo, town, capital of Akwa Ibom state, southeastern Nigeria. Uyo lies on the road from Oron to Ikot Ekpene. A collecting station for palm oil and kernels, it is also a local trade centre (yams, cassava [manioc], palm produce) for an area inhabited mainly by the Ibibio people. The town has a brewery and a textile mill.";
        public LoginRegistrationPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.GoToLoginPageCommand = new Command(this.LoginPageAction);
            this.RegisterPageCommand = new Command(this.RegisterPageAction);
        }

        private async void LoginPageAction()
        {
            var page = new LoginPage();
            await Navigation.PushAsync(page, true);
        }
        private async void RegisterPageAction()
        {
            await Navigation.PushAsync(new RegistrationPage1(), true);
        }
    }
}
