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
    public partial class ForgotPasswordView2 : ContentView
    {
        public ForgotPasswordView2()
        {
            InitializeComponent();
        }

        private async void ChangePhoneNumberClick(object sender, EventArgs e)
        {
            await(this.BindingContext as ForgotPasswordViewModel).ChangePhoneNumber();
        }

        private async void ResendOTPClick(object sender, EventArgs e)
        {
            await (this.BindingContext as ForgotPasswordViewModel).ReSendOTP();
        }
    }
}