using CustomerApp.DTOs.Financial;
using CustomerApp.Enum;
using CustomerApp.Helpers;
using CustomerApp.Models;
using CustomerApp.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebViewPG.Forms;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class PaymentPage2ViewModel : ViewModelBase
    {
        public NewSubscriptionDTO Model { get; set; } = new NewSubscriptionDTO();
        public ICommand SubmitCommand { get; set; }
        public INavigation Navigation { get; set; }

        public PaymentPage2ViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.SubmitCommand = new Command(this.SubmitAction);


            var rechargeAmount = double.Parse(App.Current.Properties["RechargeAmount"].ToString());
            this.Model.Amount = rechargeAmount;
        }

        public async Task<bool> VerifyInformation()
        {
            var page = App.Current.MainPage;

            if (string.IsNullOrEmpty(this.Model.MasterCardNumber))
            {
                await page.DisplayAlert("Incomplete", "Card Serial Number should be entered!.", "Ok");
                return false;
            }
            if (this.Model.MasterCardNumber.Length != 16)
            {
                await page.DisplayAlert("Invalid", "Card Serial Number must be of 16 characters length!.", "Ok");
                return false;
            }
            if (string.IsNullOrEmpty(this.Model.CVC))
            {
                await page.DisplayAlert("Incomplete", "CVC should be entered!.", "Ok");
                return false;
            }
            if (this.Model.CVC.ToString().Length != 3)
            {
                await page.DisplayAlert("Invalid", "CVC must be of 3 characters length!.", "Ok");
                return false;
            }
            return true;
        }

        private async void SubmitAction()
        {
            if (!await NetworkUtil.ValidateNetwork())
            {
                return;
            }

            if (await this.VerifyInformation())
            {
                // Get token from payment gateway
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
                    Plan = this.Model.Amount == 2500 ? "Monthly" : "Weekly"
                };

                var extras = new Dictionary<string, object>
                {
                    { PGExtra.ExtraCustomer, paymentDetail },
                    { PGExtra.ExtraMode, true }         // Is Live: true, Is Test: false
                };
               
                
                //var launcher = DependencyService.Get<IActivityLauncher>();
                //launcher.SetCallback((args) =>
                //{
                //if (args.Success)
                //{
                //    App.Services.Subscription.SaveSubscriptionAsync(this.Model);

                //    Navigation.DisplayMessage(ButtonTypeEnum.Home, IconTypeEnum.Success, "Payment", "Congratulation!", "Card payment successful!", "Thanks for coming onboard with Dryva");


                //}).StartPayStackActivity(extras);




            }

        }


    }
}
