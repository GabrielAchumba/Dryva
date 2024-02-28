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
    public partial class RegistrationPage1 : ContentPage
    {
        public RegistrationPage1()
        {
            InitializeComponent();
            this.BindingContext =  RegistrationPageViewModel.Instance;
        }
    }
}