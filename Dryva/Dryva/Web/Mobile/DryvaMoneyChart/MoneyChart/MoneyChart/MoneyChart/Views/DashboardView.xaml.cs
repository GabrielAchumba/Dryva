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
    public partial class DashboardView : ContentPage
    {
        public DashboardView()
        {
            InitializeComponent();
            ViewModel = new DashboardViewModel(Navigation);
            BindingContext = ViewModel;
        }

        private DashboardViewModel viewModel;

        public DashboardViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}