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
    public partial class RegistrationView3 : ContentView
    {
        public RegistrationView3()
        {
            InitializeComponent();
            ViewModel = new RegistrationView3Model();
            BindingContext = ViewModel;
        }

        private RegistrationView3Model viewModel;

        public RegistrationView3Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}