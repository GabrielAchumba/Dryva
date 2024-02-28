using MoneyChart.DTOs;
using MoneyChart.Helpers;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoneyChart.ViewModels
{
    public class CustomersViewModel: ViewModelBase
    {
        public CustomersViewModel()
        {
            Task.Run(() => GetFromAPIRegistrationDTOList());
        }

        #region Fields and Properties

        #region CustomerRegistrationDTOList
        private ObservableCollection<CustomerReportDTO> customerRegistrationDTOList;

        public ObservableCollection<CustomerReportDTO> CustomerRegistrationDTOList
        {
            get { return customerRegistrationDTOList; }
            set { SetProperty(ref customerRegistrationDTOList, value); }
        }



        #endregion
        #endregion

        #region Methods

        private async Task<int> GetFromAPIRegistrationDTOList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                //CustomerRegistrationDTOList
                //    = await App.Database.GetCustomerRegistrationListDTOAsync();
                CustomerRegistrationDTOList
                  = App.testData.customerReportDTO;
               
                
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
