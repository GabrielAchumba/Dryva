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
    public partial class VehicleStatusView : ContentPage
    {
        public VehicleStatusView()
        {
            InitializeComponent();
            ViewModel = new VehicleStatusViewModel();
            BindingContext = ViewModel;
        }

        private VehicleStatusViewModel viewModel;

        public VehicleStatusViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}