using CustomerApp.ViewModels.Registration;
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
    public partial class RegistrationPage3 : ContentPage
    {
        public RegistrationPage3()
        {
            InitializeComponent();
            this.BindingContext = RegistrationPageViewModel.Instance;
        }

        private void ChangePhoneNumberClick(object sender, EventArgs e)
        {

        }

        private async void ResendOTPClick(object sender, EventArgs e)
        {
            await RegistrationPageViewModel.Instance.Model3.ReSendOTP();
        }
    }
}