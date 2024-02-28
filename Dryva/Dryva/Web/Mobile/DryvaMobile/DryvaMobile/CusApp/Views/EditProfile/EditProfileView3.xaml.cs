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
    public partial class EditProfileView3 : ContentView
    {
        public EditProfileView3()
        {
            InitializeComponent();
            ViewModel = new EditProfileView3Model();
            BindingContext = ViewModel;
        }

        private EditProfileView3Model viewModel;

        public EditProfileView3Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}