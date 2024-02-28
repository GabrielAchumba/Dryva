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
    public partial class LoginRegisterPage : ContentPage
    {
        public LoginRegisterPage()
        {
            InitializeComponent();
            ViewModel = new LoginRegisterViewModel(Navigation);
            BindingContext = ViewModel;
        }

        private LoginRegisterViewModel viewModel;

        public LoginRegisterViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

    }
}