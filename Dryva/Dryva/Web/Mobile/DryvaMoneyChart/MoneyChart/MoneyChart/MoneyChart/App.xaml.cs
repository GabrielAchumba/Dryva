using MoneyChart.Data;
using MoneyChart.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyChart
{
    public partial class App : Application
    {
        static DryvaInvestorDatabase database;
        public static TestData testData;
        public App()
        {
            InitializeComponent();
            testData = new TestData();
            MainPage = new NavigationPage(new LogInView());
        }

        public static DryvaInvestorDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DryvaInvestorDatabase(new RestService());
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
    }
}
