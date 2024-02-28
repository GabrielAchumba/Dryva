using CusApp.Data;
using CusApp.DTOs.Customer;
using CusApp.Models;
using CusApp.Views;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CusApp
{
    public partial class App : Application
    {
        static DryvaCustomerDatabase database;
        static TestData testData;
        public App()
        {
            InitializeComponent();

            //testData = new TestData();// To be removed

            Task.Run( () =>  Authentication()).Wait();



           
        }

        public static DryvaCustomerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DryvaCustomerDatabase(new RestService());
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private async Task Authentication()
        {
            if (database == null)
            {
                database = new DryvaCustomerDatabase(new RestService());
            }
            RegistrationItem registrationItem = await App.Database.GetRegistrationItemAsync();
            if(registrationItem == null)
            {
                MainPage = new NavigationPage(new LoginRegisterPage());
            }
            else
            {

                MainPage = new NavigationPage(new CusApp.Views.MainPage());
            }

            //if (CrossConnectivity.Current.IsConnected)
            //{
            //    RegistrationDTO registrationDTO = await App.Database.GetRegistrationDTOAsyncREST();
            //    if (registrationDTO != null)
            //    {
            //        IsRegistrationEnabled = false;
            //        RegistrationStatus = "You have registerd. Thanks";
            //        IsWalletEnabled = true;

            //    }
            //    else
            //    {
            //        IsRegistrationEnabled = true;
            //        RegistrationStatus = "You have not registerd. Please register";
            //        IsWalletEnabled = false;
            //    }
            //}
            //else
            //{
            //    if (registrationItem != null)
            //    {
            //        IsRegistrationEnabled = false;
            //        RegistrationStatus = "You have registerd. Thanks";

            //    }
            //    else
            //    {
            //        IsRegistrationEnabled = true;
            //        RegistrationStatus = "You have not registerd. Please register";
            //    }
            //}
        }
    }
}
