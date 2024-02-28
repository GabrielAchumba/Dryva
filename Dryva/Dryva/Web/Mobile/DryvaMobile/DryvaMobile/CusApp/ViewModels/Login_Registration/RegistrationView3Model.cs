using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class RegistrationView3Model: ViewModelBase
    {
        public RegistrationView3Model()
        {
            #region Temporary Data
            OTPCODE = "235678";
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

        #region OTPCODE
        private string oTPCODE;

        public string OTPCODE
        {
            get { return oTPCODE; }
            set { SetProperty(ref oTPCODE, value); }
        }

        #endregion

        #endregion

        #region Methods

        public void GetInformation1()
        {
            
            if (Application.Current.Properties.ContainsKey("RegistrationView1Model_MOBILENUMBER") == true
                && Application.Current.Properties.ContainsKey("RegistrationView1Model_SelectedMOBILECODE") == true)
            {
                string mobilenumber = Convert.ToString(Application.Current.Properties["RegistrationView1Model_MOBILENUMBER"]);
                string selectedMOBILECODE = Convert.ToString(Application.Current.Properties["RegistrationView1Model_SelectedMOBILECODE"]);
                Information1 = "We are unable to auto-verify your mobile number. "
               + "please enter the code tested to " + selectedMOBILECODE + mobilenumber;
            }
            else
            {
                Information1 = "We are unable to auto-verify your mobile number. "
                    + "please enter the code tested to your phone number";
            }
        }

        #endregion
    }
}
