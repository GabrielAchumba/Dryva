using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class LogInView1Model : ViewModelBase
    {
        public LogInView1Model()
        {
            #region Temporal Data
            PHONENUMBEROREMAIL = "achumba.gabriel@yahoo.com";
            PASSWORD = "gab*012020";
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

        #region PASSWORD

        private string pASSWORD;

        public string PASSWORD
        {
            get { return pASSWORD; }
            set { SetProperty(ref pASSWORD, value); }
        }

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}
