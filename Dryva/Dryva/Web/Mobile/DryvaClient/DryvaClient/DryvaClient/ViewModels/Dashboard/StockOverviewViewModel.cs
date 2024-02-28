using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DryvaClient.Models.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DryvaClient.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for stock overview page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class StockOverviewViewModel : BaseViewModel
    {
        #region Field

        private ObservableCollection<Stock> items;

        private int selectedDataVariantIndex;

        

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="StockOverviewViewModel" /> class.
        /// </summary>
        public StockOverviewViewModel()
        {
            GetChartData();
            var variants = new List<string> { "1M", "3M", "6M", "9M", "1Y" };
            items = new ObservableCollection<Stock>()
            {
                new Stock()
                {
                    Category = "NSEI",
                    CategoryValue = 20.35,
                    SubCategory = "NIFTY 50",
                    SubCategoryValue = 6164.34,
                    DataVariants = variants,
                    IsExpandable = true
                },
                new Stock()
                {
                    Category = "BSESN",
                    CategoryValue = 26.32,
                    SubCategory = "S&P BSE SENSEX",
                    SubCategoryValue = 5649.43,
                    DataVariants = variants,
                },
                new Stock()
                {
                    Category = "AAPL",
                    CategoryValue = 26.32,
                    SubCategory = "APPLE INC",
                    SubCategoryValue = 5649.43,
                    DataVariants = variants,
                },
                new Stock()
                {
                    Category = "SBUCX",
                    CategoryValue = 26.32,
                    SubCategory = "STARSSBUCKS CORP",
                    SubCategoryValue = 5649.43,
                    DataVariants = variants,
                }
            };

            this.ProfileImage = App.BaseImageUrl + "ProfileImage1.png";
            this.DataVariantCommand = new Command(this.DataVariantClicked);
            this.MenuCommand = new Command(this.MenuClicked);
            this.SelectionCommand = new Command(this.ItemClicked);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the selected data variant index.
        /// </summary>
        public int SelectedDataVariantIndex
        {
            get
            {
                return selectedDataVariantIndex;
            }

            set
            {
                SetProperty(ref selectedDataVariantIndex, value);
            }
        }

        /// <summary>
        /// Gets or sets the stock items collection.
        /// </summary>
        public ObservableCollection<Stock> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                SetProperty(ref this.items, value);
            }
        }

        #endregion

        #region Comments
        /// <summary>
        /// Gets or sets the command that will be executed when the data variant for chart is clicked.
        /// </summary>
        public Command DataVariantCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the expand the stock item.
        /// </summary>
        public Command SelectionCommand { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Chart Data Collection
        /// </summary>
        private void GetChartData()
        {
            DateTime dateTime = new DateTime(2019, 5, 1);

          
        }

        /// <summary>
        /// Invoked when the data variant button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void DataVariantClicked(object obj)
        {
            var item = obj as Stock;
            switch (SelectedDataVariantIndex)
            {
                case 0:
                    {
                        //item.ChartData = oneMonthData;
                        break;
                    }
                case 1:
                    {
                        //item.ChartData = threeMonthData;
                        break;
                    }
                case 2:
                    {
                        //item.ChartData = sixMonthData;
                        break;
                    }
                case 3:
                    {
                        //item.ChartData = nineMonthData;
                        break;
                    }
                case 4:
                    {
                       // item.ChartData = yearData;
                        break;
                    }
            }
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ItemClicked(object obj)
        {
            var item = obj as Stock;
            foreach (var stock in Items)
            {
                if (item != stock)
                    stock.IsExpandable = false;
            }
        }

        #endregion
    }
}
