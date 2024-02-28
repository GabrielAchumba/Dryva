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
    public partial class ShareTripsPopUp : ContentView
    {
        public ShareTripsPopUp()
        {
            InitializeComponent();
            ViewModel = new ShareTripsPopUpModel();
            BindingContext = ViewModel;
        }

        private ShareTripsPopUpModel viewModel;

        public ShareTripsPopUpModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}