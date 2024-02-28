using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using WebViewPG.Droid;
using WebViewPG.Droid.PayStack;

namespace WebViewPG
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Instance = this;

            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Button btnPay = FindViewById<Button>(Resource.Id.btnPay);
            btnPay.Click += OnPay;

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        private void OnPay()
        {
            var payModel = new PaymentDetail()
            {
                Amount = 3000,
                Currency = "NGN",
                Email = "Felixgiftinfo@gmail.com",
                FirstName = "Gift",
                LastName = "Felix",
                PhoneNumber = "07030229161",
                Plan = "Yearly"
            };
            var payservice = Xamarin.Forms.DependencyService.Get<IPaymentService>();
            payservice.Pay(payModel);
        }

        private void OnPay(object sender, EventArgs e)
        {
            PGCustomer customer = new PGCustomer
            {
                Amount = 2500,
                Currency = "NGN",
                Email = "wizzyno@gmail.com",
                FirstName = "Eniefiok",
                LastName = "Eniang",
                PhoneNumber = "08069328151",
                Plan = "Monthly"
            };

            var intent = new Intent(this, typeof(PayStackActivity))
                // To format the payment page you fit your need. Use the template guide for direction
                //.PutExtra(PGCustomer.ExtraHtmlContent, "<!doctype html><html><body><!-- Your Content--></body></html>")
                .PutExtra(PGCustomer.ExtraCustomer, customer);

            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

