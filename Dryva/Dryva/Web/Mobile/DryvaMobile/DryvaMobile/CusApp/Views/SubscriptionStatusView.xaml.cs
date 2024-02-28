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
    public partial class SubscriptionStatusView : ContentPage
    {
        public SubscriptionStatusView()
        {
            InitializeComponent();
            ViewModel = new SubscriptionStatusViewModel();
            BindingContext = ViewModel;
        }

        private SubscriptionStatusViewModel viewModel;

        public SubscriptionStatusViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}