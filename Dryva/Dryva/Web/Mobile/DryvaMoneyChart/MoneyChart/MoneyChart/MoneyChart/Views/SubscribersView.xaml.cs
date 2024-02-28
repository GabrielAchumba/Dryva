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
    public partial class SubscribersView : ContentPage
    {
        public SubscribersView()
        {
            InitializeComponent();
            ViewModel = new SubscribersViewModel();
            BindingContext = ViewModel;
        }

        private SubscribersViewModel viewModel;

        public SubscribersViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}