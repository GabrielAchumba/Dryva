using MoneyChart.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoneyChart.ViewModels
{
    public class DashboardViewModel: ViewModelBase
    {
        public DashboardViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            InitializeData();
        }

        #region Fields and Properties

        public INavigation Navigation { get; set; }

        public ICommand CustomersReportCommand { private set; get; }
        public ICommand SubscribersReportCommand { private set; get; }
        public ICommand ProfitReportCommand { private set; get; }

        private string customersSummaryReport;

        public string CustomersSummaryReport
        {
            get { return customersSummaryReport; }
            set { SetProperty(ref customersSummaryReport, value); }
        }

        private string subscribersSummaryReport;

        public string SubscribersSummaryReport
        {
            get { return subscribersSummaryReport; }
            set { SetProperty(ref subscribersSummaryReport, value); }
        }

        private string profitSummaryReport;

        public string ProfitSummaryReport
        {
            get { return profitSummaryReport; }
            set { SetProperty(ref profitSummaryReport, value); }
        }

        private string cAPEXOPEXSummaryReport;

        public string CAPEXOPEXSummaryReport
        {
            get { return cAPEXOPEXSummaryReport; }
            set { SetProperty(ref cAPEXOPEXSummaryReport, value); }
        }

        #endregion

        #region Methods

        private void InitializeData()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {

            GetDashboardUpdates();
            this.CustomersReportCommand = new Command(async () => await CustomersReportAction());
            this.SubscribersReportCommand = new Command(async () => await SubscribersReportAction());
            this.ProfitReportCommand = new Command(async () => await ProfitReportAction());

        }

        private void GetDashboardUpdates()
        {
            CustomersSummaryReport = "";
            SubscribersSummaryReport = "";
            ProfitSummaryReport = "";
        }

        private async Task CustomersReportAction()
        {

            await Navigation.PushAsync(new CustomersView());
        }

        private async Task SubscribersReportAction()
        {

            await Navigation.PushAsync(new SubscribersView());
        }

        private async Task ProfitReportAction()
        {
            await Navigation.PushAsync(new InvestorProfitView());
        }

       

        #endregion
    }
}
