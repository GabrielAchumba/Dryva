using CustomerApp.DTOs.Financial;
using CustomerApp.Enum;
using CustomerApp.Helpers;
using CustomerApp.Services;
using CustomerApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebViewPG.Forms;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class PaymentPageViewModel : ViewModelBase
    {

        public PaymentSubscriptionDTO Model { get; } = new PaymentSubscriptionDTO();

        #region MonthlyImageSource
        private ImageSource monthlyImageSource;

        public ImageSource MonthlyImageSource
        {
            get { return monthlyImageSource; }
            set { SetProperty(ref monthlyImageSource, value); }
        }
        #endregion

        #region WeeklyImageSource
        private ImageSource weeklyImageSource;

        public ImageSource WeeklyImageSource
        {
            get { return weeklyImageSource; }
            set { SetProperty(ref weeklyImageSource, value); }
        }
        #endregion
        public ImageSource StarImageSource { get; set; }
        public ImageSource GoodImageSource { get; set; }

        public ICommand PreviewCommand { get; set; }
        public INavigation Navigation { get; set; }

        private PaymentPlanEnum paymentPlan;
        public PaymentPlanEnum PaymentPlan
        {
            get { return paymentPlan; }
            set
            {
                SetProperty(ref paymentPlan, value);
                if (value == PaymentPlanEnum.Monthly)
                    this.Model.Amount = 2500;
                else
                    this.Model.Amount = 750;
                this.Model.PaymentPlan = value;
            }
        }

        public PaymentPageViewModel(INavigation navigation)
        {
            this.PreviewCommand = new Command(this.PreviewPaymentAction);
            this.Navigation = navigation;
            this.SetDefault();
        }

        private void SetDefault()
        {
            StarImageSource = ImageSource.FromFile("failure.png");
            GoodImageSource = ImageSource.FromFile("success.png");
            MonthlyImageSource = GoodImageSource;
            WeeklyImageSource = StarImageSource;
            this.PaymentPlan = PaymentPlanEnum.Monthly;
        }


        public void MonthlyModeAction()
        {
            MonthlyImageSource = GoodImageSource;
            WeeklyImageSource = StarImageSource;
            this.PaymentPlan = PaymentPlanEnum.Monthly;
        }

        public void WeeklyModeAction()
        {
            MonthlyImageSource = StarImageSource;
            WeeklyImageSource = GoodImageSource;
            this.PaymentPlan = PaymentPlanEnum.Weekly;
        }

        private async void PreviewPaymentAction()
        {
            var customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            this.Model.CustomerId = customerInfo.CustomerId;

            if (!customerInfo.Csn.HasValue)
            {
                await App.Current.MainPage.DisplayAlert("Incomplete Registration", "Customer meter serial number has not been registered. \nPlease contact the nearest Dryva's office.", "Ok");
                return;
            }


            this.Model.CardSerialNumber = customerInfo.Csn.Value;

            var paymentDetail = new PaymentDetail()
            {
                Amount = this.Model.Amount,
                Currency = "NGN",
                Email = customerInfo.Email,
                FirstName = customerInfo.FirstName,
                LastName = customerInfo.LastName,
                PhoneNumber = customerInfo.PhoneNumber,
                Plan = this.Model.PaymentPlan.ToString()
            };

            var extras = new Dictionary<string, object>
            {
                { PGExtra.ExtraCustomer, paymentDetail },
                { PGExtra.ExtraMode, true }         // Is Live: true, Is Test: false
            };
            var launcher = DependencyService.Get<IActivityLauncher>();
            launcher.SetCallback((args) =>
            {
                if (args.Success)
                {
                    var data = App.Services.Subscription.SaveSubscriptionAsync(this.Model).Result;
                    //if (data.IsSuccess)
                    //{
                    //}
                }

            }).StartPayStackActivity(extras);


        }
    }
}
