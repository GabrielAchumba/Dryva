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
    public partial class EditProfilePage2 : ContentPage
    {
        public EditProfilePage2()
        {
            InitializeComponent();
            this.BindingContext = EditProfilePageViewModel.Instance;
        }

        private async void UploadPix_Click(object sender, EventArgs e)
        {
            var vm = EditProfilePageViewModel.Instance;
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                Stream _stream = _mediaFile.GetStream();
                vm.NewUploadPhotograph = ImageUtil.GetImageStreamAsBytes(_stream);

                this.imgPix.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
            }
        }
    }
}