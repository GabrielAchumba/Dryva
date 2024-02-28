using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class LogInView3Model: ViewModelBase
    {
        public LogInView3Model()
        {
            Information1 = "Please enter OTP Code";

            #region Temporary Data
            OTPCode = "245677";
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

        #region OTPCode

        private string oTPCode;

        public string OTPCode
        {
            get { return oTPCode; }
            set { SetProperty(ref oTPCode, value); }
        }

        #endregion

        #endregion

        #region Methods

        #endregion
    }
}
