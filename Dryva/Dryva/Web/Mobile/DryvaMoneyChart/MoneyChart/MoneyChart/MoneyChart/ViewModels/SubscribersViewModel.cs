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
    public class SubscribersViewModel: ViewModelBase
    {
        public SubscribersViewModel()
        {
            Task.Run(() => GetFromAPISubscribersDTOList());
        }

        #region Fields and Properties

        #region SubscribersDTOList
        private ObservableCollection<SubscriberReportDTO> subscribersDTOList;

        public ObservableCollection<SubscriberReportDTO> SubscribersDTOList
        {
            get { return subscribersDTOList; }
            set { SetProperty(ref subscribersDTOList, value); }
        }



        #endregion
        #endregion

        #region Methods

        private async Task<int> GetFromAPISubscribersDTOList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                //SubscribersDTOList CustomerRegistrationListDTO
                //    = await App.Database.GetSubscribersDTODTOAsync();
                SubscribersDTOList
                   = App.testData.subscriberReportDTO;
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
