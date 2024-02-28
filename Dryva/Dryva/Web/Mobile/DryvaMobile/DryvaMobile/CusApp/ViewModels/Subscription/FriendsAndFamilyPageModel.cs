using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class FriendsAndFamilyPageModel: ViewModelBase
    {
        public FriendsAndFamilyPageModel()
        {
            LoadFriendsAndFamilyList();
            isDeletePopUpVisible = false;
            IsShareTripsPopUpVisible = false;
            this.ShareUnitCommand = new Command(() =>  ShareUnitAction());
            this.DeleteBeneficiaryCommand = new Command(() =>  DeleteBeneficiaryAction());
        }

        #region Fields and Properties

        #region Commands

        public ICommand ShareUnitCommand { private set; get; }

        public ICommand DeleteBeneficiaryCommand { private set; get; }
        #endregion

        #region FriendsAndFamilyList
        private ObservableCollection<FriendsAndFamilyModel> friendsAndFamilyList;

        public ObservableCollection<FriendsAndFamilyModel> FriendsAndFamilyList
        {
            get { return friendsAndFamilyList; }
            set { SetProperty(ref friendsAndFamilyList, value); }
        }

        #endregion

        #region IsDeletePopUpVisible
        private bool isDeletePopUpVisible;

        public bool IsDeletePopUpVisible
        {
            get { return isDeletePopUpVisible; }
            set { SetProperty(ref isDeletePopUpVisible, value); }
        }

        #endregion

        #region IsShareTripsPopUpVisible
        private bool isShareTripsPopUpVisible;

        public bool IsShareTripsPopUpVisible
        {
            get { return isShareTripsPopUpVisible; }
            set { SetProperty(ref isShareTripsPopUpVisible, value); }
        }

        #endregion

        #endregion

        #region Methods

        private void LoadFriendsAndFamilyList()
        {
            FriendsAndFamilyList = new ObservableCollection<FriendsAndFamilyModel>()
            {
                new FriendsAndFamilyModel()
                {
                    BeneficiaryName="Gift Felix",
                    SerialNumber="1."
                },
                new FriendsAndFamilyModel()
                {
                    BeneficiaryName="Charles Alison",
                    SerialNumber="2."
                },new FriendsAndFamilyModel()
                {
                    BeneficiaryName="Gideon Sanni",
                    SerialNumber="3."
                },new FriendsAndFamilyModel()
                {
                    BeneficiaryName="Abba Chiroma",
                    SerialNumber="4."
                }

            };
        }

        private void ShareUnitAction()
        {
            IsShareTripsPopUpVisible = true;
            isDeletePopUpVisible = false;
        }

        private void DeleteBeneficiaryAction()
        {
            IsShareTripsPopUpVisible = false;
            isDeletePopUpVisible = true;
        }

            #endregion
        }

    public class FriendsAndFamilyModel
    {
        public FriendsAndFamilyModel()
        {

        }

        public string SerialNumber { get; set; }
        public string BeneficiaryName { get; set; }
    }
}
