using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class EditProfileView1Model: ViewModelBase
    {
        public EditProfileView1Model()
        {
            PopulateMOBILECODELIST();

            #region Temporary data
            FIRSTNAME = "Gabriel";
            LASTNAME = "Achumba";
            EMAIL = "achumba.gabriel@yahoo.com";
            SelectedMOBILECODEIndex = 2;
            #endregion
        }

        #region Fields and Properties
      

        #region FIRSTNAME
        private string fIRSTNAME;

        public string FIRSTNAME
        {
            get { return fIRSTNAME; }
            set { SetProperty(ref fIRSTNAME, value); }
        }


        #endregion

        #region LASTNAME
        private string lASTNAME;

        public string LASTNAME
        {
            get { return lASTNAME; }
            set { SetProperty(ref lASTNAME, value); }
        }


        #endregion

        #region EMAIL
        private string eMAIL;

        public string EMAIL
        {
            get { return eMAIL; }
            set { SetProperty(ref eMAIL, value, "EMAIL", value); }
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
                    SetProperty(ref selectedMOBILECODEIndex, value, "EditProfileView1Model_SelectedMOBILECODE", SelectedMOBILECODE.CountryMobileCode);
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
            set { SetProperty(ref mOBILENUMBER, value, "EditProfileView1Model_MOBILENUMBER", value); }
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
