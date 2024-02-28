using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.ViewModels
{
    public class PaymentView2Model: ViewModelBase
    {
        public PaymentView2Model()
        {
            EXPIRYDATE = DateTime.Now;
            IsDebitCardViewVisible = false;
            IsBankDraftViewVisible = false;
            LoadBankNameLIST();

            #region Temporary Data
            DEBITCARDNUMBER = "2222 2222 2222 2222";
            cARDHOLDER = "Gabriel Achumba";
            CVS = "922";
            ACCOUNTNUMBER = "20882300000";
            SelectedBankNameIndex = 1;
            #endregion
        }

        #region Fields and Properties

        #region DEBITCARDNUMBER
        private string dEBITCARDNUMBER;

        public string DEBITCARDNUMBER
        {
            get { return dEBITCARDNUMBER; }
            set { SetProperty(ref dEBITCARDNUMBER, value); }
        }


        #endregion

        #region CARDHOLDER
        private string cARDHOLDER;

        public string CARDHOLDER
        {
            get { return cARDHOLDER; }
            set { SetProperty(ref cARDHOLDER, value); }
        }


        #endregion

        #region EXPIRYDATE
        private DateTime eXPIRYDATE;

        public DateTime EXPIRYDATE
        {
            get { return eXPIRYDATE; }
            set { SetProperty(ref eXPIRYDATE, value); }
        }


        #endregion

        #region CVS
        private string cVS;

        public string CVS
        {
            get { return cVS; }
            set { SetProperty(ref cVS, value); }
        }


        #endregion

        #region IsDebitCardViewVisible
        private bool isDebitCardViewVisible;

        public bool IsDebitCardViewVisible
        {
            get { return isDebitCardViewVisible; }
            set { SetProperty(ref isDebitCardViewVisible, value); }
        }


        #endregion

        #region IsBankDraftViewVisible
        private bool isBankDraftViewVisible;

        public bool IsBankDraftViewVisible
        {
            get { return isBankDraftViewVisible; }
            set { SetProperty(ref isBankDraftViewVisible, value); }
        }


        #endregion

        #region ACCOUNTNUMBER
        private string aCCOUNTNUMBER;

        public string ACCOUNTNUMBER
        {
            get { return aCCOUNTNUMBER; }
            set { SetProperty(ref aCCOUNTNUMBER, value); }
        }


        #endregion

        #region SelectedBankNameIndex
        private int selectedBankNameIndex;

        public int SelectedBankNameIndex
        {
            get { return selectedBankNameIndex; }

            set
            {

                if (value != -1)
                {
                    SelectedBankName = BankNameLIST[value];
                    SetProperty(ref selectedBankNameIndex, value);
                }
                else
                {
                    SelectedBankName = BankNameLIST[0];
                    SetProperty(ref selectedBankNameIndex, 0);
                }

            }
        }


        #endregion

        #region SelectedBankName
        public string SelectedBankName { get; set; }


        #endregion

        #region BankNameLIST
        private List<string> bankNameLIST;

        public List<string> BankNameLIST
        {
            get { return bankNameLIST; }
            set { SetProperty(ref bankNameLIST, value); }
        }


        #endregion


        

        #endregion

        #region Methods

        public void EnableAndDisableViews(bool _IsDebitCardViewVisible,bool _IsBankDraftViewVisible)
        {
            IsBankDraftViewVisible = _IsBankDraftViewVisible;
            IsDebitCardViewVisible = _IsDebitCardViewVisible;
        }

        private void LoadBankNameLIST()
        {
            BankNameLIST = new List<string>()
            {
                "First","Zenith","Access","GTB","Fidelity","UBA","Unioun"
            };
        }

        #endregion
    }
}
