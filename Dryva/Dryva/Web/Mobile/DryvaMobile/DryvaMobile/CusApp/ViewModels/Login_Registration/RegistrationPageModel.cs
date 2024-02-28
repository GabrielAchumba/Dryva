using CusApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class RegistrationPageModel: ViewModelBase
    {


        public RegistrationPageModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            RegistrationView1 = new RegistrationView1();
            RegistrationView2 = new RegistrationView2();
            RegistrationView3 = new RegistrationView3();
            RegistrationView4 = new RegistrationView4();
            DynamicView = RegistrationView1;
            LeftText = "";
            RightText = "";
            IsRightChecked = false;
            IsLeftChecked = false;
            IsLeftStackLayoutVisible = false;
            IsRightStackLayoutVisible = false;
            DynamicCaption = "NEXT";
            this.DynamicCommand = new Command(async () => await DynamicAction());
        }

        #region Fields and Properties

        #region Command

        public INavigation Navigation { get; set; }

        public ICommand DynamicCommand { private set; get; }
        public View RegistrationView1 { get; set; }
        public View RegistrationView2 { get; set; }
        public RegistrationView3 RegistrationView3 { get; set; }
        public View RegistrationView4 { get; set; }

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

        #region IsLeftChecked
        private bool isLeftChecked;

        public bool IsLeftChecked
        {
            get { return isLeftChecked; }
            set { SetProperty(ref isLeftChecked, value); }
        }

        #endregion

        #region IsRightChecked
        private bool isRightChecked;

        public bool IsRightChecked
        {
            get { return isRightChecked; }
            set { SetProperty(ref isRightChecked, value); }
        }

        #endregion

        #region LeftText
        private string leftText;

        public string LeftText
        {
            get { return leftText; }
            set { SetProperty(ref leftText, value); }
        }

        #endregion

        #region RightText
        private string rightText;

        public string RightText
        {
            get { return rightText; }
            set { SetProperty(ref rightText, value); }
        }

        #endregion

        #region IsLeftStackLayoutVisible
        private bool isLeftStackLayoutVisible;

        public bool IsLeftStackLayoutVisible
        {
            get { return isLeftStackLayoutVisible; }
            set { SetProperty(ref isLeftStackLayoutVisible, value); }
        }

        #endregion

        #region IsRightStackLayoutVisible
        private bool isRightStackLayoutVisible;

        public bool IsRightStackLayoutVisible
        {
            get { return isRightStackLayoutVisible; }
            set { SetProperty(ref isRightStackLayoutVisible, value); }
        }

        #endregion

        #endregion

        #region Methods

        private async Task DynamicAction()
        {

            if (DynamicView == RegistrationView1)
            {

                DynamicView = RegistrationView2;
                LeftText = "";
                RightText = "";
                IsLeftStackLayoutVisible = false;
                IsRightStackLayoutVisible = false;
                DynamicCaption = "SKIP";
            }
            else if (DynamicView == RegistrationView2)
            {
                RegistrationView3.ViewModel.GetInformation1();
                DynamicView = RegistrationView3;
                LeftText = "CHANGE NUMBER";
                RightText = "RESEND CODE";
                IsLeftStackLayoutVisible = true;
                IsRightStackLayoutVisible = true;
                DynamicCaption = "SUBMIT";
            }
            else if (DynamicView == RegistrationView3)
            {

                DynamicView = RegistrationView4;
                LeftText = "";
                RightText = "";
                IsLeftStackLayoutVisible = false;
                IsRightStackLayoutVisible = false;
                DynamicCaption = "LOGIN";
            }
            else
            {
                await Navigation.PushAsync(new LoginRegisterPage());                
            }



        }

       

        #endregion
    }
}
