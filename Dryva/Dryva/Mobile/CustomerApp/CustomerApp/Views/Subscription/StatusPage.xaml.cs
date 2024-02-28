using CustomerApp.Helpers;
using CustomerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatusPage : ContentPage
    {
        public StatusPage()
        {
            InitializeComponent();
            this.BindingContext = new StatusPageModel();

            this.RunTaks();
        }

        private void RunTaks()
        {
            var customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            if (customerInfo.Photo != null)
                this.imgPix.Source = ImageUtil.GetImageSource(customerInfo.Photo);
        }
    }
}