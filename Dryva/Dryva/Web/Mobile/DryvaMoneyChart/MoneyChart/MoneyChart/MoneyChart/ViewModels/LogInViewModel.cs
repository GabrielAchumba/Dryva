using MoneyChart.DTOs;
using MoneyChart.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoneyChart.ViewModels
{
    public class LogInViewModel: ViewModelBase
    {
        public LogInViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.LogInCommand = new Command(async () => await LogInAction());

        }

        #region Fields and Properties

        public INavigation Navigation { get; set; }

        public ICommand LogInCommand { private set; get; }

        #region PinCode
        private long pinCode;

        public long PinCode
        {
            get { return pinCode; }
            set { SetProperty(ref pinCode, value); }
        }

        #endregion

        #region LoginStatuts
        private string loginStatuts;

        public string LoginStatuts
        {
            get { return loginStatuts; }
            set { SetProperty(ref loginStatuts, value); }
        }
        #endregion
        #endregion

        #region Methods

        private async Task<int> ComfirmPinAndLogIn()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                //InvestorDTO investorDTO
                //    = await App.Database.GetInvestorDTOAsync();
                InvestorDTO investorDTO
                    = App.testData.investorDTO;
                if(investorDTO.Pin == pinCode)
                {
                    await Navigation.PushAsync(new DashboardView());
                }
                else
                {
                    LoginStatuts = "Wrong pin code";
                }

            }
            else
            {
                var task = Application.Current?.MainPage?.DisplayAlert("Dryva Alert", "No internet connection", "OK");
            }

            return 1;
        }

        private async Task LogInAction()
        {
           await ComfirmPinAndLogIn();
        }
        #endregion
    }
}
