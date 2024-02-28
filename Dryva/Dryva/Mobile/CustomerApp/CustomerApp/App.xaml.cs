using CustomerApp.Services;
using CustomerApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CustomerApp.Views;
using Plugin.Connectivity;
using CustomerApp.Helpers;

namespace CustomerApp
{
    public partial class App : Application
    {
        static DryvaCustomerDatabase databaseServices;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            Task.Run(() => Authentication()).Wait();
        }

        public static DryvaCustomerDatabase Services
        {
            get
            {
                if (databaseServices == null)
                {
                    databaseServices = new DryvaCustomerDatabase();
                }
                return databaseServices;
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
            //////await this.TestCRUD();
            
            App.Current.Properties.Clear();

            CustomerInfo customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            if (customerInfo == null)
            {
                MainPage = new NavigationPage(new LoginRegistrationPage());
            }
            else
            {
                // Download network customer data to local.
                if (CrossConnectivity.Current.IsConnected)
                {
                    await SetCustomerInformation(customerInfo);
                }
            }
            if (customerInfo != null)
            {
                if (customerInfo.RememberMe)
                {
                    MainPage = new NavigationPage(new MasterMenu());
                }
                else
                {
                    var page = new LoginPage();
                    MainPage = new NavigationPage(page);
                }
            }
        }

        public async Task SetCustomerInformation(CustomerInfo loginInfo)
        {
            var customerInfo = await App.Services.Customer.GetCustomerByPhoneNumberAsync(loginInfo.PhoneNumber);
            var customerData = customerInfo.Data;
            if (customerData != null)
            {
                App.Current.Properties.Add(NameConstant.CustomerOnlineData, customerData);
                loginInfo.SetData(customerData);
                await App.Services.Customer.SaveCustomerDetail_Local(loginInfo);
            }
        }


        #region To be used

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
        #endregion

    }
}

