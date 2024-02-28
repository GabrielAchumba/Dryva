using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class ShareTripsPopUpModel: ViewModelBase
    {
        public ShareTripsPopUpModel()
        {
            this.CancelCommand = new Command(async () => await CancelAction());
            this.OKCommand = new Command(async () => await OKAction());

            #region Temporary Data
            HeaderCaption = "Dryva Trips Gabriel";
            Information1 = "How many trips do you want to send to " + "Gideon Sanni" + "?";
            NumberofTrips = "5";
            TripsValue = "N 125";
            #endregion
        }

        #region Fields and Properties

        #region Command

        public ICommand CancelCommand { private set; get; }

        public ICommand OKCommand { private set; get; }
        #endregion

        #region HeaderCaption
        private string headerCaption;

        public string HeaderCaption
        {
            get { return headerCaption; }
            set { SetProperty(ref headerCaption, value); }
        }


        #endregion

        #region Information1
        private string information1;

        public string Information1
        {
            get { return information1; }
            set { SetProperty(ref information1, value); }
        }


        #endregion

        #region NumberofTrips
        private string numberofTrips;

        public string NumberofTrips
        {
            get { return numberofTrips; }
            set { SetProperty(ref numberofTrips, value); }
        }


        #endregion

        #region TripsValue
        private string tripsValue;

        public string TripsValue
        {
            get { return tripsValue; }
            set { SetProperty(ref tripsValue, value); }
        }


        #endregion

        #endregion

        #region Methods

        private async Task CancelAction()
        {

        }


        private async Task OKAction()
        {

        }

        #endregion
    }
}
