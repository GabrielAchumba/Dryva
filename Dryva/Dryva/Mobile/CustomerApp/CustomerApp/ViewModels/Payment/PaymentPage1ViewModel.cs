using CustomerApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class PaymentPage1ViewModel : ViewModelBase
    {
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

        public ImageSource StarImageSource { get; set; }
        public ImageSource GoodImageSource { get; set; }

        public ICommand NextCommand { get; set; }
        public INavigation Navigation { get; set; }
        private bool IsDebitCardSelected = false;

        private bool _isToggled;
        public bool IsToggled
        {
            get { return _isToggled; }
            set
            {
                _isToggled = value;
                this.SetAmountAInfo();
                this.RaisePropertyChanged();
            }
        }

        private string _amountInfo;
        public string AmountInfo
        {
            get { return _amountInfo; }
            set { _amountInfo = value; this.RaisePropertyChanged(); }
        }

        public PaymentPage1ViewModel(INavigation navigation)
        {
            this.NextCommand = new Command(this.NextAction);
            this.Navigation = navigation;
            this.SetDefault();
            this.SetAmountAInfo();
        }

        private void SetDefault()
        {
            StarImageSource = ImageSource.FromFile("failure.png");
            GoodImageSource = ImageSource.FromFile("success.png");
            DebitCardImageSource = GoodImageSource;
            BankDraftImageSource = StarImageSource;
            this.IsDebitCardSelected = true;
        }

        private void SetAmountAInfo()
        {
            double amount = 0;
            if (this.IsToggled)
            {
                this.AmountInfo = "NGN 2500 (30 Days)";
                amount = 2500;
            }
            else
            {
                this.AmountInfo = "NGN 750 (7 Days)";
                amount = 750;
            }
            App.Current.Properties["RechargeAmount"] = amount;
        }

        public void DebitCardAction()
        {
            DebitCardImageSource = GoodImageSource;
            BankDraftImageSource = StarImageSource;
            this.IsDebitCardSelected = true;
        }

        public void BankDraftAction()
        {
            DebitCardImageSource = StarImageSource;
            BankDraftImageSource = GoodImageSource;
            this.IsDebitCardSelected = false;
        }

        private async void NextAction()
        {
            if (this.IsDebitCardSelected)
            {
                await this.Navigation.PushAsync(new PaymentPage2(), true);
            }
            else
            {
                await this.Navigation.PushAsync(new PaymentPage3(), true);
            }
        }
    }
}
