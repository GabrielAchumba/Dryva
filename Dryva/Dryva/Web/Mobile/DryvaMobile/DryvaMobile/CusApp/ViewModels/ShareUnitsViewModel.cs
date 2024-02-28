using CusApp.DTOs.Financial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class ShareUnitsViewModel: ViewModelBase
    {
        public ShareUnitsViewModel()
        {
            stackLayoutVisibility = false;
            this.ShareUnitsCommand = new Command(async () => await ShareUnitsAction());
            InitializeNumberOfPersonsList();
        }

        #region Fields and Properties

        public ICommand ShareUnitsCommand { private set; get; }

        #region NumberOfPersons
        private int numberOfPersons;

        public int NumberOfPersons
        {
            get { return numberOfPersons; }
            set
            {
                SetProperty(ref numberOfPersons, value);
                InitializeShareUnitDTOList();
            }
        }
        #endregion

        #region ShareUnitDTOList

        private List<ShareUnitDTO> shareUnitDTOList;

        public List<ShareUnitDTO> ShareUnitDTOList
        {
            get { return shareUnitDTOList; }
            set {
                SetProperty(ref shareUnitDTOList, value);

            }
        }

        #endregion


        #region NumberOfPersonsList

        private IList<int> numberOfPersonsList;

        public IList<int> NumberOfPersonsList
        {
            get { return numberOfPersonsList; }
            set
            {
                SetProperty(ref numberOfPersonsList, value);

            }
        }

        #endregion

        #region StackLayoutVisibility
        private bool stackLayoutVisibility;

        public bool StackLayoutVisibility
        {
            get { return stackLayoutVisibility; }
            set {
                SetProperty(ref stackLayoutVisibility, value);
            }
        }

        #endregion



        #endregion

        #region Methods

        private void InitializeNumberOfPersonsList()
        {
            NumberOfPersonsList = new List<int>();
            for (int i = 0; i < 30; i++)
            {
                NumberOfPersonsList.Add(i + 1);
            }
        }
        private void InitializeShareUnitDTOList()
        {
            stackLayoutVisibility = true;
            ShareUnitDTOList = new List<ShareUnitDTO>();
            for (int i = 0; i < numberOfPersons; i++)
            {
                ShareUnitDTOList.Add(new ShareUnitDTO());
            }
        }

        private async Task<int> ShareUnitsAction()
        {
            //await App.Database.SaveShareUnitDTOListAsync(ShareUnitDTOList);
            return 1;
        }

        #endregion
    }
}
