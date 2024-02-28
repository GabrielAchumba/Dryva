using CusApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
            ViewModel = new EditProfilePageModel();
            BindingContext = ViewModel;
        }

        private EditProfilePageModel viewModel;

        public EditProfilePageModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}