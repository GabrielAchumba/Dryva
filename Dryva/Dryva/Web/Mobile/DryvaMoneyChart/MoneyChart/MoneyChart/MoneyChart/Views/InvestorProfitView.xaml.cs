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
    public partial class InvestorProfitView : ContentPage
    {
        public InvestorProfitView()
        {
            InitializeComponent();
            ViewModel = new InvestorProfitViewModel();
            BindingContext = ViewModel;
        }

        private InvestorProfitViewModel viewModel;

        public InvestorProfitViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}