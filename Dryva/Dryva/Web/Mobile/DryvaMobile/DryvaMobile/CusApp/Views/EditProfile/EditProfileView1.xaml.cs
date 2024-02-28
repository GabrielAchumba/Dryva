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
    public partial class EditProfileView1 : ContentView
    {
        public EditProfileView1()
        {
            InitializeComponent();
            ViewModel = new EditProfileView1Model();
            BindingContext = ViewModel;
        }

        private EditProfileView1Model viewModel;

        public EditProfileView1Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}