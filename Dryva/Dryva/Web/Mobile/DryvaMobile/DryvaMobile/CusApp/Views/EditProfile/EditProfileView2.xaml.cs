using CusApp.Helpers;
using CusApp.ViewModels;
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
    public partial class EditProfileView2 : ContentView
    {
        public EditProfileView2()
        {
            InitializeComponent();
            ViewModel = new EditProfileView2Model();
            BindingContext = ViewModel;
        }

        private EditProfileView2Model viewModel;

        public EditProfileView2Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

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