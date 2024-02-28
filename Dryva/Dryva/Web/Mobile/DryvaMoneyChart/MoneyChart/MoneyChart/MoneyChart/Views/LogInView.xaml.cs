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
    public partial class LogInView : ContentPage
    {
        public LogInView()
        {
            InitializeComponent();
            ViewModel = new LogInViewModel(Navigation);
            BindingContext = ViewModel;
        }

        private LogInViewModel viewModel;

        public LogInViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}