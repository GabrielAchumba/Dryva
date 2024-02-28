using MoneyChart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyChart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomersView : ContentPage
    {
        public CustomersView()
        {
            InitializeComponent();
            ViewModel = new CustomersViewModel();
            BindingContext = ViewModel;
        }

        private CustomersViewModel viewModel;

        public CustomersViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}