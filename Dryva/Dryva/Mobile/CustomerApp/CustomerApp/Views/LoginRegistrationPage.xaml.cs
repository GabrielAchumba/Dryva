using CustomerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginRegistrationPage : ContentPage
    {
        public LoginRegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginRegistrationPageViewModel(this.Navigation);
        }
    }
}