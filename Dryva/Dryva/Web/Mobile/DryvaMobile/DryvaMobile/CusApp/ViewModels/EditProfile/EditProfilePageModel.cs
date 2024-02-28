using CusApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class EditProfilePageModel: ViewModelBase
    {
        public EditProfilePageModel()
        {
            EditProfileView1 = new EditProfileView1();
            EditProfileView2 = new EditProfileView2();
            EditProfileView3 = new EditProfileView3();
            DynamicView = EditProfileView1;
            DynamicCaption = "NEXT";
            this.DynamicCommand = new Command(async () => await DynamicAction());
        }

        #region Fields and Properties

        #region Command


        public ICommand DynamicCommand { private set; get; }
        public View EditProfileView1 { get; set; }
        public View EditProfileView2 { get; set; }
        public View EditProfileView3 { get; set; }

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

  

        #endregion

        #region Methods

        private async Task DynamicAction()
        {

            if (DynamicView == EditProfileView1)
            {

                DynamicView = EditProfileView2;
                DynamicCaption = "SKIP";
            }
            else if (DynamicView == EditProfileView2)
            {
                DynamicView = EditProfileView3;
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
