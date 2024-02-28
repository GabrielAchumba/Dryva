using CusApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class LoginPageModel: ViewModelBase
    {
        public LoginPageModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            LogInView1 = new LogInView1();
            LogInView2 = new LogInView2();
            LogInView3 = new LogInView3();
            LogInView4 = new LogInView4();
            LogInView5 = new LogInView5();
            DynamicView = LogInView1;
            LeftText = "REMEMBER ME";
            RightText = "FORGOT PASSWORD?";
            IsRightChecked = false;
            IsLeftChecked = false;
            IsLeftStackLayoutVisible = true;
            IsRightStackLayoutVisible = true;
            DynamicCaption = "LOGIN";
            this.DynamicCommand = new Command(async () => await DynamicAction());
        }

        #region Fields and Properties

        #region Command

        public INavigation Navigation { get; set; }

        public ICommand DynamicCommand { private set; get; }
        public View LogInView1 { get; set; }
        public View LogInView2 { get; set; }
        public View LogInView3 { get; set; }
        public View LogInView4 { get; set; }
        public View LogInView5 { get; set; }

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

            if (DynamicView == LogInView1 && RightText == "FORGOT PASSWORD?"
                && IsRightChecked == false)
            {
                IsLeftStackLayoutVisible = true;
                IsRightStackLayoutVisible = true;
                App.Current.MainPage = new NavigationPage(new CusApp.Views.MainPage());
                //MainPage = new NavigationPage(new CusApp.Views.MainPage());
                //await Navigation.PushAsync(new CusApp.Views.MainPage());
            }
            else if (DynamicView == LogInView1 && RightText == "FORGOT PASSWORD?"
                && IsRightChecked == true)
            {

                DynamicView = LogInView2;
                LeftText = "";
                RightText = "";
                IsLeftStackLayoutVisible = false;
                IsRightStackLayoutVisible = false;
                DynamicCaption = "RESET PASSWORD";
            }
            else if (DynamicView == LogInView2 && IsRightChecked == true)
            {

                DynamicView = LogInView3;
                LeftText = "CHANGE NUMBER";
                RightText = "RESEND CODE";
                IsLeftStackLayoutVisible = true;
                IsRightStackLayoutVisible = true;
                DynamicCaption = "SUBMIT";
            }
            else if (DynamicView == LogInView3 && IsRightChecked == true)
            {

                DynamicView = LogInView4;
                LeftText = "CHANGE NUMBER";
                RightText = "RESEND CODE";
                IsLeftStackLayoutVisible = false;
                IsRightStackLayoutVisible = false;
                DynamicCaption = "SUBMIT";
            }
            else if (DynamicView == LogInView4)
            {
                DynamicView = LogInView5;
                LeftText = "";
                RightText = "";
                IsLeftStackLayoutVisible = false;
                IsRightStackLayoutVisible = false;
                DynamicCaption = "LOGIN";
            }
            else
            {
                DynamicView = LogInView1;
                LeftText = "REMEMBER ME";
                RightText = "FORGOT PASSWORD?";
                IsLeftStackLayoutVisible = true;
                IsRightStackLayoutVisible = true;
                DynamicCaption = "LOGIN";
            }


           
        }

       
            #endregion

        }
}
