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
    public partial class FriendsAndFamilyPage : ContentPage
    {
        public FriendsAndFamilyPage()
        {
            InitializeComponent();
            ViewModel = new FriendsAndFamilyPageModel();
            BindingContext = ViewModel;
        }

        private FriendsAndFamilyPageModel viewModel;

        public FriendsAndFamilyPageModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}