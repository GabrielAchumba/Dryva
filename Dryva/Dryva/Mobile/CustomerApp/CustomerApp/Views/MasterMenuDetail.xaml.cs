using CustomerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenuDetail : ContentPage
    {

        public MasterMenuDetail()
        {

            InitializeComponent();
            //ViewModel = new MasterMenuDetailViewModel();
            //BindingContext = ViewModel;
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(
            //    new Position(ViewModel.Latitude, ViewModel.Longitude), Distance.FromMiles(1.0)));
        }

        private MasterMenuDetailViewModel viewModel;

        public MasterMenuDetailViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }


        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }

        
            // <!--xmlns:maps="clr-namespace:Xamarin.Forms.Maps;assembly=Xamarin.Forms.Maps"-->

    }
}