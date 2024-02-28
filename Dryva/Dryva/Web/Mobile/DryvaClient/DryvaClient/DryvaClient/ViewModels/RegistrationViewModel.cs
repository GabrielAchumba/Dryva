using DryvaClient.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DryvaClient.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
     
        public RegistrationViewModel(INavigation navigation)
        {
            
            this.Navigation = navigation;
            this.RegistrationCommand = new Command(async() => await RegistrationAction());
            InitializeData();
        }
        #region Fields and Properties


        

        #region Commands

        public INavigation Navigation { get; set; }

        public ICommand RegistrationCommand { private set; get; }

        #endregion

        #region GenderList

        private IList<string> genderList;

        public IList<string> GenderList
        {
            get { return genderList; }
            set { SetProperty(ref genderList, value); }
        }

        #endregion

        #region SelectedGender

        private string selectedGender;

        public string SelectedGender
        {
            get { return selectedGender; }
            set { SetProperty(ref selectedGender, value); }
        }

        #endregion

        #region Title

        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        #endregion

        #region Surname

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { SetProperty(ref surname, value); }
        }

        #endregion

        #region FirstName

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        #endregion

        #region OtherName

        private string otherName;

        public string OtherName
        {
            get { return otherName; }
            set { SetProperty(ref otherName, value); }
        }

        #endregion

        #region Username

        private string username;

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        #endregion

        #region Password

        private string password;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        #endregion

        #region Email

        private string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        #endregion

        #region PhoneNumber

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set {
                string name = this.ToString();
                SetProperty(ref phoneNumber, value);
            }
        }

        #endregion



        #endregion

        #region Methods

        #region InitializeData
        private void InitializeData()
        {
            PopulateGenderList();
        }
        #endregion
        private void PopulateGenderList()
        {
            GenderList = new List<string> { "Male", "Female" };
        }

        private async Task RegistrationAction()
        {
            await Navigation.PushAsync(new DashboardPage());
            //MapData.SaveRegistrationData();
        }
        #endregion

        public override string ToString()
        {
            return "RegistrationViewModel";
        }
    }
}
