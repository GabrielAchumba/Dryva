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
    public partial class RegistrationView1 : ContentView
    {
        public RegistrationView1()
        {
            InitializeComponent();
            ViewModel = new RegistrationView1Model();
            BindingContext = ViewModel;
        }

        private RegistrationView1Model viewModel;

        public RegistrationView1Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}