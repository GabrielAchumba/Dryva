using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class RegistrationView2Model: ViewModelBase
    {
        public RegistrationView2Model()
        {
            BIRTHDATE = DateTime.Now;
            #region Temporary Data
            STATE = "Akwa Ibom";
            CITY = "Uyo";
            #endregion
        }

        #region Fields and Properties

        #region STATE
        private string sTATE;

        public string STATE
        {
            get { return sTATE; }
            set { SetProperty(ref sTATE, value); }
        }


        #endregion

        #region CITY
        private string cITY;

        public string CITY
        {
            get { return cITY; }
            set { SetProperty(ref cITY, value); }
        }


        #endregion

        #region BIRTHDATE
        private DateTime bIRTHDATE;

        public DateTime BIRTHDATE
        {
            get { return bIRTHDATE; }
            set { SetProperty(ref bIRTHDATE, value); }
        }


        #endregion

      
        #endregion
    }
}
