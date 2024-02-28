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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            ViewModel = new RegistrationPageModel(Navigation);
            BindingContext = ViewModel;
        }

        private RegistrationPageModel viewModel;

        public RegistrationPageModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}