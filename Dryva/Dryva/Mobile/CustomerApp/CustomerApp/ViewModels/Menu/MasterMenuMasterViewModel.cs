using CustomerApp.Models;
using CustomerApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class MasterMenuMasterViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public INavigation Navigation { get; }
        public List<MasterPageItem> MasterPageItems { get; set; } = new List<MasterPageItem>();
        public ICommand EditprofileCommand { get; set; }

        public MasterMenuMasterViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.LoadMenuItems();
            this.SetData();
            this.EditprofileCommand = new Command(this.EditProfileAction);
        }

        private void SetData()
        {
            CustomerInfo customerInfo = App.Services.Customer.GetCustomerDetail_Local();
            this.Name = $"{customerInfo.LastName} { customerInfo.FirstName}";
            this.Photo = customerInfo.Photo;
        }
        private void LoadMenuItems()
        {
            MasterPageItems = new List<MasterPageItem>()
            {
                new MasterPageItem()
                {
                    Title="Home Page",
                    IconSource="map.png",
                    TargetType = typeof(MasterMenuDetail)
                },
                 new MasterPageItem()
                {
                    Title="Subscription",
                    IconSource="wallet.png",
                    TargetType = typeof(SubscriptionPage)
                },
                  new MasterPageItem()
                {
                    Title="Payment",
                    IconSource="payment.png",
                    TargetType = typeof(PaymentPage)
                },
                //   new MasterPageItem()
                //{
                //    Title="History",
                //    IconSource="dashboard4.png",
                //    TargetType = typeof(PaymentPage1)
                //},
                //    new MasterPageItem()
                //{
                //    Title="Notifications",
                //    IconSource="dashboard4.png",
                //    TargetType = typeof(MasterMenuDetail)
                //},
                //    new MasterPageItem()
                //{
                //    Title="Settings",
                //    IconSource="dashboard4.png",
                //    TargetType = typeof(MasterMenuDetail)
                //},
                //    new MasterPageItem()
                //{
                //    Title="Help",
                //    IconSource="dashboard4.png",
                //    TargetType = typeof(MasterMenuDetail)
                //},
                    new MasterPageItem()
                {
                    Title="Logout",
                    IconSource="Logout.png"
                }
            };

            // MenuListView.ItemsSource = MasterPageItems;
        }

        private async void EditProfileAction()
        {
            await Navigation.PushAsync(new EditProfilePage1(), true);
        }
    }
}
