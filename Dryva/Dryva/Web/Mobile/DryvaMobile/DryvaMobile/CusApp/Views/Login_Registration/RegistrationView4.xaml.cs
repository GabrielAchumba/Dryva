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
    public partial class RegistrationView4 : ContentView
    {
        public RegistrationView4()
        {
            InitializeComponent();
            ViewModel = new RegistrationView4Model();
            BindingContext = ViewModel;
        }

        private RegistrationView4Model viewModel;

        public RegistrationView4Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}