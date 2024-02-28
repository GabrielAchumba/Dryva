using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class PaymentView1Model : ViewModelBase
    {
        public PaymentView1Model()
        {
            DebitCardViewVisible = false;
            BankViewVisible = false;
            DebitCardColor = Color.White;
            BankDraftColor = Color.White;
            StarImageSource= ImageSource.FromFile("ButtonImage2.png");
            GoodImageSource = ImageSource.FromFile("ButtonImage3.png");
            DebitCardImageSource = StarImageSource;
            BankDraftImageSource = StarImageSource;
            this.DebitCardCommand = new Command(() =>  DebitCardAction());
            this.BankDraftCommand = new Command( () =>  BankDraftAction());
            App.Current.Properties["DebitCardViewVisible"] = DebitCardViewVisible;
            App.Current.Properties["BankViewVisible"] = BankViewVisible;

            #region Temporary Data
            PROMOCODE = "235679";
            #endregion

        }

        #region Fields and Properties

        public ICommand DebitCardCommand { private set; get; }
        public ICommand BankDraftCommand { private set; get; }


        #region PROMOCODE

        private string pROMOCODE;

        public string PROMOCODE
        {
            get { return pROMOCODE; }
            set { SetProperty(ref pROMOCODE, value); }
        }
        #endregion

        #region DebitCardColor

        private Color debitCardColor;

        public Color DebitCardColor
        {
            get { return debitCardColor; }
            set { SetProperty(ref debitCardColor, value); }
        }

        #endregion

        #region BankDraftColor
        private Color bankDraftColor;

        public Color BankDraftColor
        {
            get { return bankDraftColor; }
            set { SetProperty(ref bankDraftColor, value); }
        }
        #endregion

        #region DebitCardImageSource
        private ImageSource debitCardImageSource;

        public ImageSource DebitCardImageSource
        {
            get { return debitCardImageSource; }
            set { SetProperty(ref debitCardImageSource, value); }
        }
        #endregion

        #region BankDraftImageSource
        private ImageSource bankDraftImageSource;

        public ImageSource BankDraftImageSource
        {
            get { return bankDraftImageSource; }
            set { SetProperty(ref bankDraftImageSource, value); }
        }
        #endregion

        public bool DebitCardViewVisible { get; set; }
        public bool BankViewVisible { get; set; }
        public ImageSource StarImageSource { get; set; }
        public ImageSource GoodImageSource { get; set; }




        #endregion

        #region Methods


        private void DebitCardAction()
        {
            if(DebitCardViewVisible == false)
            {
                
                DebitCardViewVisible = true;
                DebitCardColor = Color.LightGray;
                DebitCardImageSource = GoodImageSource;



                BankViewVisible = false;
                BankDraftColor = Color.White;
                BankDraftImageSource = StarImageSource;
            }
            else 
            { 
                
                DebitCardViewVisible = false;
                DebitCardColor = Color.White;
                DebitCardImageSource = StarImageSource;

                BankViewVisible = false;
                BankDraftColor = Color.White;
                BankDraftImageSource = StarImageSource;
            }

            App.Current.Properties["DebitCardViewVisible"] = DebitCardViewVisible;
            App.Current.Properties["BankViewVisible"] = BankViewVisible;
        }

        private void BankDraftAction()
        {
            if (BankViewVisible == false)
            {
                BankViewVisible = true;
                BankDraftColor = Color.LightGray;
                BankDraftImageSource = GoodImageSource;

                DebitCardViewVisible = false;
                DebitCardColor = Color.White;
                DebitCardImageSource = StarImageSource;
            }
            else
            {
                BankViewVisible = false;
                BankDraftColor = Color.White;
                BankDraftImageSource = StarImageSource;
                

                DebitCardViewVisible = false;
                DebitCardColor = Color.White;
                DebitCardImageSource = StarImageSource;
            }

            App.Current.Properties["DebitCardViewVisible"] = DebitCardViewVisible;
            App.Current.Properties["BankViewVisible"] = BankViewVisible;

        }

        #endregion
    }

   
}
