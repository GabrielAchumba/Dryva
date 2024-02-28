using CustomerApp.Helpers;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class StatusPageModel : ViewModelBase
    {
        public StatusPageModel()
        {
            //#region Temporary Data
            //CreditBalance = "N 1,750";
            //TripsBalance = 70;
            //SubscriptionExpiry = "20th July, 2022";
            //#endregion

            Task.Run(() => this.Getsubscriptions());
        }

        #region Fields and Properties

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; this.RaisePropertyChanged(); }
        }

        private string statusName = "Active";
        public string StatusName
        {
            get { return statusName; }
            set { statusName = value; this.RaisePropertyChanged(); }
        }

        private Color statusColor = Color.Green;
        public Color StatusColor
        {
            get { return statusColor; }
            set { statusColor = value; this.RaisePropertyChanged(); }
        }

        private string creditBalance = "0.00";
        public string CreditBalance
        {
            get { return creditBalance; }
            set { creditBalance = value; this.RaisePropertyChanged(); }
        }

        private int tripsBalance = 0;
        public int TripsBalance
        {
            get { return tripsBalance; }
            set { tripsBalance = value; this.RaisePropertyChanged(); }
        }


        #region SubscriptionExpiry

        private string subscriptionExpiry;

        public string SubscriptionExpiry
        {
            get { return subscriptionExpiry; }
            set { SetProperty(ref subscriptionExpiry, value); }
        }

        #endregion


        #endregion

        #region Methods
        private async Task Getsubscriptions()
        {
            var customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            if (NetworkUtil.IsConnected())
            {
                var models = await App.Services.Subscription.GetSusbcriptions(customerInfo.CustomerId);
                var model = models.Data;
                if (model != null)
                {
                    customerInfo.CreditBalance = model.DepleteAmount;
                    customerInfo.TripsBalance = model.AvailableTrips;
                    customerInfo.IsActive = model.IsActive;

                    await App.Services.Customer.SaveCustomerDetail_Local(customerInfo);
                }
            }

            this.Name = $"{customerInfo.LastName} { customerInfo.FirstName}";
            this.CreditBalance = $"N { String.Format("{0:n}", customerInfo.CreditBalance)}";
            this.TripsBalance = customerInfo.TripsBalance;
            this.StatusName = customerInfo.IsActive ? "Active" : "Inactive";
            this.StatusColor = customerInfo.IsActive ? Color.Green : Color.Red;

        }
        #endregion
    }
}
