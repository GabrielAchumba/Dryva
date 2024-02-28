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
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class PaymentPage3ViewModel : ViewModelBase
    {

        public NewSubscriptionDTO Model { get; set; } = new NewSubscriptionDTO();
        public ICommand SubmitCommand { get; set; }

        public INavigation Navigation { get; set; }
        public PaymentPage3ViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.SubmitCommand = new Command(this.SubmitAction);
        }

        public async Task<bool> VerifyInformation()
        {
            var page = App.Current.MainPage;
            if (string.IsNullOrEmpty(this.Model.AccountNumber))
            {
                await page.DisplayAlert("Incomplete", "Account Number should be entered!.", "Ok");
                return false;
            }
            if (string.IsNullOrEmpty(this.Model.SelectedBank))
            {
                await page.DisplayAlert("Incomplete", "Bank not selected!.", "Ok");
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
                    await App.Current.MainPage.DisplayAlert("Incomplete Registration", "Customer meter serial number is not valid \n Please contact the nearest Dryva's office.", "Ok");
                    return;
                }

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


                //var result = App.Services.Subscription.DoPayment(paymentDetail);
                //if (!string.IsNullOrEmpty(result))
                //{
                //    var data = await App.Services.Subscription.SaveSubscriptionAsync(this.Model);
                //    await Navigation.DisplayMessage(ButtonTypeEnum.Home, IconTypeEnum.Success, "Payment", "Congratulation!", "Card payment successful!", "Thanks for coming onboard with Dryva");
                //}
                //else
                //{

                //}
            }

        }
    }
}
