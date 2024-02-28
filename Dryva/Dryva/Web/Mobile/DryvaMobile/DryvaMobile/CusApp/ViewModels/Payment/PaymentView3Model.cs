using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class PaymentView3Model: ViewModelBase
    {
        public PaymentView3Model()
        {
            Information1 = "We use your email & mobile number to send you ride confirmations & receipts";
            PopulateMOBILECODELIST();
            #region Temporary Data
            SelectedMOBILECODEIndex = 2;
            MOBILENUMBER = "+234-(0)7032488605";
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

        #region SelectedMOBILECODEIndex
        private int selectedMOBILECODEIndex;

        public int SelectedMOBILECODEIndex
        {
            get { return selectedMOBILECODEIndex; }

            set
            {

                if (value != -1)
                {
                    SelectedMOBILECODE = MOBILECODELIST2[value];
                    SetProperty(ref selectedMOBILECODEIndex, value, "PaymentView3Model_SelectedMOBILECODE", SelectedMOBILECODE.CountryMobileCode);
                }
                else
                {
                    SelectedMOBILECODE = MOBILECODELIST2[0];
                    SetProperty(ref selectedMOBILECODEIndex, 0);
                }

            }
        }


        #endregion

        #region SelectedMOBILECODE
        public MOBILECODE SelectedMOBILECODE { get; set; }


        #endregion

        #region MOBILECODELIST
        private List<string> mOBILECODELIST;

        public List<string> MOBILECODELIST
        {
            get { return mOBILECODELIST; }
            set { SetProperty(ref mOBILECODELIST, value); }
        }


        #endregion


        #region MOBILECODELIST2
        private List<MOBILECODE> mOBILECODELIST2;

        public List<MOBILECODE> MOBILECODELIST2
        {
            get { return mOBILECODELIST2; }
            set { SetProperty(ref mOBILECODELIST2, value); }
        }


        #endregion



        #region MOBILENUMBER
        private string mOBILENUMBER;

        public string MOBILENUMBER
        {
            get { return mOBILENUMBER; }
            set { SetProperty(ref mOBILENUMBER, value, "PaymentView3Model_MOBILENUMBER", value); }
        }

        #endregion
        #endregion

        #region Methods

        private void PopulateMOBILECODELIST()
        {
            MOBILECODELIST2 = new List<MOBILECODE>()
            {
                new MOBILECODE()
                {
                    CountryName="Cameroon",
                    CountryMobileCode="+237"
                },
                new MOBILECODE()
                {
                    CountryName="Ghana",
                    CountryMobileCode="+233"
                },
                new MOBILECODE()
                {
                    CountryName="Nigeria",
                    CountryMobileCode="+234"
                },
                new MOBILECODE()
                {
                    CountryName="South Africa",
                    CountryMobileCode="+27"
                }
            };

            MOBILECODELIST = new List<string>() { "Cameroon", "Ghana", "Nigeria", "South Africa" };

        }

        #endregion
    }
}
