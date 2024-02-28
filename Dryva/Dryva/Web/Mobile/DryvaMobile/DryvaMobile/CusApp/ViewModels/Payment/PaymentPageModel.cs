using CusApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class PaymentPageModel: ViewModelBase
    {

        public PaymentPageModel()
        {
            PaymentView1 = new PaymentView1();
            PaymentView2 = new PaymentView2();
            PaymentView3 = new PaymentView3();
            PaymentView4 = new PaymentView4();
            DynamicView = PaymentView1;
            DynamicCaption = "NEXT";
            this.DynamicCommand = new Command(async () => await DynamicAction());
        }

        #region Fields and Properties

        #region Command


        public ICommand DynamicCommand { private set; get; }
        public View PaymentView1 { get; set; }
        public PaymentView2 PaymentView2 { get; set; }
        public View PaymentView3 { get; set; }
        public View PaymentView4 { get; set; }

        #endregion

        #region DynamicCaption

        private string dynamicCaption;

        public string DynamicCaption
        {
            get { return dynamicCaption; }
            set { SetProperty(ref dynamicCaption, value); }
        }

        #endregion

        #region DynamicView
        private View dynamicView;

        public View DynamicView
        {
            get { return dynamicView; }
            set { SetProperty(ref dynamicView, value); }
        }

        #endregion

        public bool DebitCardViewVisible { get; set; }
        public bool BankViewVisible { get; set; }

        #endregion

        #region Methods

        private async Task DynamicAction()
        {

            if (DynamicView == PaymentView1)
            {
                DebitCardViewVisible = Convert.ToBoolean(App.Current.Properties["DebitCardViewVisible"]);
                BankViewVisible = Convert.ToBoolean(App.Current.Properties["BankViewVisible"]);
                PaymentView2.ViewModel.EnableAndDisableViews(DebitCardViewVisible, BankViewVisible);
                DynamicView = PaymentView2;
                DynamicCaption = "SUBMIT";
            }
            else if (DynamicView == PaymentView2)
            {

                DynamicView = PaymentView3;
                DynamicCaption = "SAVE AND VERIFY";
            }
            else if (DynamicView == PaymentView3)
            {

                DynamicView = PaymentView4;
                DynamicCaption = "HOME";
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new CusApp.Views.MainPage());
            }



        }


        #endregion
    }
}
