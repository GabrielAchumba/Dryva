using CustomerApp.Helpers;
using CustomerApp.ViewModels.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage1 : ContentPage
    {
        public EditProfilePage1()
        {
            InitializeComponent();
            this.BindingContext = EditProfilePageViewModel.Instance;

            this.RunTaks();
        }
        private void RunTaks()
        {
            EditProfilePageViewModel.Instance.SetInformation();
            this.imgPix.Source = ImageUtil.GetImageSource(EditProfilePageViewModel.Instance.Photograph);

            EditProfilePageViewModel.Instance.SetCustomerInformation();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //this.RunTaks();
        }
    }
}