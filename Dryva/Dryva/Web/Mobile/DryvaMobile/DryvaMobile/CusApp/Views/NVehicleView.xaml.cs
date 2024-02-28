using CusApp.Models;
using CusApp.ViewModels;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NVehicleView : ContentPage
    {
       
        public NVehicleView()
        {
            
            InitializeComponent();
            ViewModel = new NVehicleViewModel();
            BindingContext = ViewModel;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(ViewModel.Latitude, ViewModel.Longitude), Distance.FromMiles(1.0)));
        }

        private NVehicleViewModel viewModel;

        public NVehicleViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }


        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }

    }
}