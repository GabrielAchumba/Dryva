using CusApp.Models;
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
    public partial class MasterPage : ContentPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MasterPage()
        {
            InitializeComponent();
            ViewModel = new MasterPageModel();
            BindingContext = ViewModel;
        }

        private MasterPageModel viewModel;

        public MasterPageModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}