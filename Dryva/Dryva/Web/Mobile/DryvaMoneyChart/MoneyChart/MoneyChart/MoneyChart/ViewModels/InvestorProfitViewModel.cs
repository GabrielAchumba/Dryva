using MoneyChart.DTOs;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoneyChart.ViewModels
{
    public class InvestorProfitViewModel:ViewModelBase
    {
        public InvestorProfitViewModel()
        {
            Task.Run(() => GetFromAPIInvestorProfitList());
        }

        #region Fields and Properties

       
        #region InvestorProfitList
        private InvestorProfitDTO investorProfitList;

        public InvestorProfitDTO InvestorProfitList
        {
            get { return investorProfitList; }
            set { SetProperty(ref investorProfitList, value); }
        }

        #endregion
        #endregion

        #region Methods

        private async Task<int> GetFromAPIInvestorProfitList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                //InvestorProfitDTO InvestorProfitList
                //    = await App.Database.GetInvestorProfitDTOAsync();
                InvestorProfitList
                    = App.testData.InvestorProfitDTO;
            }
            else
            {
                var task = Application.Current?.MainPage?.DisplayAlert("Dryva Alert", "No internet connection", "OK");
            }

            return 1;
        }
        #endregion
    }
}
