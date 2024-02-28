using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class LogInView4Model: ViewModelBase
    {
        public LogInView4Model()
        {
            Information1 = "Please enter your new password";
            #region Temporary Data
            NEWPASSWORD = "gab*012020";
            REPEATPASSWORD = "gab*012020";
            #endregion
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

        #region NEWPASSWORD

        private string nEWPASSWORD;

        public string NEWPASSWORD
        {
            get { return nEWPASSWORD; }
            set { SetProperty(ref nEWPASSWORD, value); }
        }

        #endregion

        #region REPEATPASSWORD

        private string rEPEATPASSWORD;

        public string REPEATPASSWORD
        {
            get { return rEPEATPASSWORD; }
            set { SetProperty(ref rEPEATPASSWORD, value); }
        }

        #endregion

        #endregion

        #region Methods


        #endregion
    }
}
