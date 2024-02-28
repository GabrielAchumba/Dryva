using CusApp.Helpers;
using CusApp.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationView2 : ContentView
    {
        public RegistrationView2()
        {
            InitializeComponent();
            ViewModel = new RegistrationView2Model();
            BindingContext = ViewModel;
        }

        private RegistrationView2Model viewModel;

        public RegistrationView2Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

        ////private async void Handle_Clicked2(object sender, EventArgs e)
        ////{
        ////    await CrossMedia.Current.Initialize();

        ////    //if(!CrossMedia.Current.IsTakePhotoSupported
        ////    //    || !CrossMedia.Current.IsCameraAvailable)
        ////    //{

        ////    //}

        ////    if (!CrossMedia.Current.IsPickPhotoSupported)
        ////    {
        ////        await DisplayAlert("Not supported",
        ////            "Your device does not currently support this functionality", "OK");
        ////    }

        ////    var mdediaOptions = new PickMediaOptions()
        ////    {
        ////        PhotoSize = PhotoSize.Medium
        ////    };

        ////    var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mdediaOptions);

        ////    if(selectedImage == null)
        ////    {
        ////        await DisplayAlert("Error", "Could not get the image, please try again.",
        ////            "OK");
        ////    }

        ////    selectedImage.Source
        ////        = ImageSource.FromStream(() => selectedImageFile.GetStream());
        ////}

        private async void Handle_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                selectedImage.Source = ImageSource.FromStream(() => stream);
                App.Current.Properties["Image"] = selectedImage;
            }

            (sender as Button).IsEnabled = true;
        }
    }
}