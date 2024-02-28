using CusApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class MasterPageModel: ViewModelBase
    {
        public MasterPageModel()
        {
            LASTNAME = "";
            FIRSTNAME = "";
            if (App.Current.Properties.ContainsKey("Image"))
            {
                Image image = (Image)App.Current.Properties["Image"];
                Dashboard1 = image.Source;
            }

            if(App.Current.Properties.ContainsKey("FIRSTNAME"))
            {
                FIRSTNAME = Convert.ToString(App.Current.Properties["FIRSTNAME"]);
            }

            if (App.Current.Properties.ContainsKey("LASTNAME"))
            {
                LASTNAME = Convert.ToString(App.Current.Properties["LASTNAME"]);
            }

            FullName = FIRSTNAME + " " + LASTNAME;
            this.EditprofileCommand = new Command(async () => await EditprofileAction());

            Dashboard1 = ImageSource.FromFile("login.png");
        }

        #region Fields and Properties

        public INavigation Navigation { get; set; }

        public ICommand EditprofileCommand { private set; get; }

        #region Dashboard1
        private ImageSource dashboard1;

        public ImageSource Dashboard1
        {
            get { return dashboard1; }
            set { SetProperty(ref dashboard1, value); }
        }

        #endregion

        #region FullName
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { SetProperty(ref fullName, value); }
        }

        #endregion

        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }

        #endregion

        #region Methods

        private async Task EditprofileAction()
        {
            App.Current.MainPage = new NavigationPage(new EditProfilePage());
        }
            #endregion
        }
}
