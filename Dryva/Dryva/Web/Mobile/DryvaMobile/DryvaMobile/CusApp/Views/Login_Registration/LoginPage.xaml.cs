using CusApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            ViewModel = new LoginPageModel(Navigation);
            BindingContext = ViewModel;
        }

        private LoginPageModel viewModel;

        public LoginPageModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}