using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class StatusPageModel: ViewModelBase
    {
        public StatusPageModel()
        {
            #region Temporary Data

            PictureSource = ImageSource.FromFile("PictureSource.png");
            Statusolor = Color.Green;
            FirstNameStatus = "Gabriel's Status";
            CreditBalance = "N 1,750";
            TripsBalance = "70";
            SubscriptionExpiry = "20th July, 2022";
            #endregion
        }

        #region Fields and Properties

        #region PictureSource

        private ImageSource pictureSource;

        public ImageSource PictureSource
        {
            get { return pictureSource; }
            set { SetProperty(ref pictureSource, value); }
        }

        #endregion

        #region Statusolor

        private Color statusolor;

        public Color Statusolor
        {
            get { return statusolor; }
            set { SetProperty(ref statusolor, value); }
        }

        #endregion

        #region FirstNameStatus

        private string firstNameStatus;

        public string FirstNameStatus
        {
            get { return firstNameStatus; }
            set { SetProperty(ref firstNameStatus, value); }
        }

        #endregion

        #region CreditBalance

        private string creditBalance;

        public string CreditBalance
        {
            get { return creditBalance; }
            set { SetProperty(ref creditBalance, value); }
        }

        #endregion

        #region TripsBalance

        private string tripsBalance;

        public string TripsBalance
        {
            get { return tripsBalance; }
            set { SetProperty(ref tripsBalance, value); }
        }

        #endregion

        #region SubscriptionExpiry

        private string subscriptionExpiry;

        public string SubscriptionExpiry
        {
            get { return subscriptionExpiry; }
            set { SetProperty(ref subscriptionExpiry, value); }
        }

        #endregion


        #endregion

        #region Methods

        #endregion
    }
}
