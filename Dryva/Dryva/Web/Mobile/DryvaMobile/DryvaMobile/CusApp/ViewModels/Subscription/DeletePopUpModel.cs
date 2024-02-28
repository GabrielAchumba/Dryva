using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class DeletePopUpModel: ViewModelBase
    {
        public DeletePopUpModel()
        {
            this.NoCommand = new Command(async () => await NoAction());
            this.YesCommand = new Command(async () => await YesAction());

            #region Temporary data
            Information1 = "Do you want to remove " + "Gideon Sanni" + "?";
            #endregion
        }

        #region Fields and Properties

        #region Command

        public ICommand NoCommand { private set; get; }

        public ICommand YesCommand { private set; get; }
        #endregion


        #region Information1
        private string information1;

        public string Information1
        {
            get { return information1; }
            set { SetProperty(ref information1, value); }
        }


        #endregion

        #endregion

        #region Methods

        private async Task NoAction()
        {

        }


        private async Task YesAction()
        {

        }

        #endregion
    }
}


