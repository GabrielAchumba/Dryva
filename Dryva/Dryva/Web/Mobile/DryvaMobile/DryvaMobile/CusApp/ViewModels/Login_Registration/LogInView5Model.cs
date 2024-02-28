using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class LogInView5Model: ViewModelBase
    {
        public LogInView5Model()
        {
            Information1 = "Success!";
            Information2 = "Password Changed";
        }

        #region Fields and Properties

        #region Information1

        private string information1;

        public string Information1
        {
            get { return information1; }
            set { SetProperty(ref information1, value); }
        }

        #endregion

        #region Information2

        private string information2;

        public string Information2
        {
            get { return information2; }
            set { SetProperty(ref information2, value); }
        }

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}
