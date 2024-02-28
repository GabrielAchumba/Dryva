using CustomerApp.Helpers;
using CustomerApp.ViewModels.Registration;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage2 : ContentPage
    {
        public RegistrationPage2()
        {
            InitializeComponent();
            this.BindingContext = RegistrationPageViewModel.Instance;
        }

        private async void UploadImage_Click(object sender, EventArgs e)
        {
            var vm = RegistrationPageViewModel.Instance;
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                vm.Busy();
                var _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                Stream _stream = _mediaFile.GetStream();
                vm.Model2.Photograph = ImageUtil.GetImageStreamAsBytes(_stream);

                this.imgPix.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                vm.NotBusy();
            }
        }
    }
}