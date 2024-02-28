using DryvaClient.Views.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DryvaClient.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            //hamburgerButton.Image = (FileImageSource)ImageSource.FromFile("hamburgericon.png");
            List<string> list = new List<string>();
            //list.Add("Home");
            list.Add("Dashboard");
            list.Add("Wallet");
            list.Add("Booking");
            list.Add("Subscription");
            list.Add("Share Trips");
            listView.ItemsSource = list;
        }

        void hamburgerButton_Clicked(object sender, EventArgs e) => navigationDrawer.ToggleDrawer();

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           

            switch (e.SelectedItem.ToString())
            {
                case "Dashboard":
                    await Navigation.PushAsync(new StockOverviewPage());
                    break;

                case "Wallet":
                    await Navigation.PushAsync(new CheckoutPage());
                    break;

                case "Booking":
                    await Navigation.PushAsync(new CheckoutPage());
                    break;

                case "Subscription":
                    await Navigation.PushAsync(new CheckoutPage());
                    break;

                case "Share Trips":
                    await Navigation.PushAsync(new CheckoutPage());
                    break;
            }
            navigationDrawer.ToggleDrawer();
        }
    }
}