using CusApp.DTOs.Financial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CusApp.ViewModels
{
    public class SubscriptionStatusViewModel : ViewModelBase
    {
        public SubscriptionStatusViewModel()
        {
            InitializeSerachingTimeList();
            SelectedSerachingTime = 0;
            GetSubscriptionDTOList();
            //Task.Run(() => this.GetSubscriptionDTOList()).Wait();

        }

        #region Field and Properties

        #region SerachingTimeList
        private IList<double> serachingTimeList;

        public IList<double> SerachingTimeList
        {
            get { return serachingTimeList; }
            set { SetProperty(ref serachingTimeList, value); }
        }
        #endregion

        #region SelectedSerachingTime
        private double selectedSerachingTime;

        public double SelectedSerachingTime
        {
            get { return selectedSerachingTime; }
            set { SetProperty(ref selectedSerachingTime, value);
                //if(SerachingTimeList != null)
                //    SearchData();

            }
        }
        #endregion

        public List<SubscriptionDTO> TempDataSubscriptionDTOList;

        #region SubscriptionDTOList
        private List<SubscriptionDTO> subscriptionDTOList;

        public List<SubscriptionDTO> SubscriptionDTOList
        {
            get { return subscriptionDTOList; }
            set { SetProperty(ref subscriptionDTOList, value); }
        }
        #endregion

        #endregion

        #region Methods

        private void InitializeSerachingTimeList()
        {
            SerachingTimeList = new List<double>();
            for (double i = 0; i < 200; i=i+5)
            {
                SerachingTimeList.Add(i + 1);
            }
        }
        private  void GetSubscriptionDTOList()
        {
            //SubscriptionDTOList = await App.Database.GetSubscriptionDTOListAsyncREST();
            //TempDataSubscriptionDTOList = new List<SubscriptionDTO>(SubscriptionDTOList);
            SubscriptionDTOList = new List<SubscriptionDTO>();
            decimal amount = 2500;int trips = 100;
            for (int i = 0; i < 20; i++)
            {
                amount = amount - 25;
                trips = trips - 1;
                SubscriptionDTOList.Add(new SubscriptionDTO()
                {
                    DateofPayment = new DateTime(2020, 1, i + 1),
                    Amount = amount,
                    Units = trips
                }) ;
                amount = amount - 25;
                trips = trips - 1;
                SubscriptionDTOList.Add(new SubscriptionDTO()
                {
                    DateofPayment = new DateTime(2020, 1, i + 1),
                    Amount = amount,
                    Units = trips
                });
            }


        }

        private void SearchData()
        {

            //thats all you need to make a search  

            if (SelectedSerachingTime == 0)
            {
                SubscriptionDTOList = new List<SubscriptionDTO>(TempDataSubscriptionDTOList);
            }

            else
            {
                DateTime TargetDate = DateTime.Now.AddDays(-selectedSerachingTime);
                SubscriptionDTOList = new List<SubscriptionDTO>();

                for (int i = 0; i < TempDataSubscriptionDTOList.Count; i++)
                {
                    if (TempDataSubscriptionDTOList[i].DateofPayment >= TargetDate)
                    {
                        SubscriptionDTOList.Add(TempDataSubscriptionDTOList[i]);
                    }
                }

            }
        }
        #endregion
    }
}
