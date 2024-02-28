using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WebViewPG.Forms;

namespace TestWebViewPG
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnMakePayment_Clicked(object sender, EventArgs e)
        {
            var customer = new
            {
                Amount = 100,
                Currency = "NGN",
                FirstName = "Gift",
                LastName = "Felix",
                PhoneNumber = "08167080180",
                Plan = "Daily",
                Email = "felixgiftinfo@gmail.com",
                Mode="FG"
            };
            var extras = new Dictionary<string, object>
            {
                { PGExtra.ExtraCustomer, customer },
                { PGExtra.ExtraMode, true }         // Is Live: true, Is Test: false
            };
            var launcher = DependencyService.Get<IActivityLauncher>();
            launcher.SetCallback((args) =>
            {
                var ar = args;

            }).StartPayStackActivity(extras);
        }
    }
}
