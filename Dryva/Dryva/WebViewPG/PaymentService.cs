using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WebViewPG;
using WebViewPG.Droid;
using WebViewPG.Droid.PayStack;
using Xamarin.Forms;

[assembly: Dependency(typeof(IPaymentService))]
namespace WebViewPG
{
    public interface IPaymentService
    {
        void Pay(IPaymentDetail paymentDetail);
    }
    public class PaymentService : IPaymentService
    {
        public void Pay(IPaymentDetail paymentDetail)
        {
            PGCustomer customer = new PGCustomer
            {
                Amount = paymentDetail.Amount,
                Currency = paymentDetail.Currency,
                Email = paymentDetail.Email,
                FirstName = paymentDetail.FirstName,
                LastName = paymentDetail.LastName,
                PhoneNumber = paymentDetail.PhoneNumber,
                Plan = paymentDetail.Plan
            };

            var intent = new Intent(MainActivity.Instance, typeof(PayStackActivity))
                // To format the payment page you fit your need. Use the template guide for direction
                //.PutExtra(PGCustomer.ExtraHtmlContent, "<!doctype html><html><body><!-- Your Content--></body></html>")
                .PutExtra(PGCustomer.ExtraCustomer, customer);

            MainActivity.Instance.StartActivity(intent);
        }
    }

    public interface IPaymentDetail
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        decimal Amount { get; set; }
        string Currency { get; set; }
        string Plan { get; set; }
    }

    public class PaymentDetail: IPaymentDetail
    {
       public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Plan { get; set; }
    }



}