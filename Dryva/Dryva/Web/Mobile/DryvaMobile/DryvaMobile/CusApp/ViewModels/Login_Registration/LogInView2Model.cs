using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class LogInView2Model: ViewModelBase
    {
        public LogInView2Model()
        {
            Information1 = "Don't worry! Just enter your email or phone number "
                + "below and we will send you the password resect instructions";

            #region Temporary Data

            PHONENUMBEROREMAIL = "+234-(0)7032488605";
            #endregion
        }

        #region Fields and Properties

        #region PHONENUMBEROREMAIL

        private string pHONENUMBEROREMAIL;

        public string PHONENUMBEROREMAIL
        {
            get { return pHONENUMBEROREMAIL; }
            set { SetProperty(ref pHONENUMBEROREMAIL, value); }
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

        #endregion
    }
}
