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
    public partial class LogInView5 : ContentView
    {
        public LogInView5()
        {
            InitializeComponent();
            ViewModel = new LogInView5Model();
            BindingContext = ViewModel;
        }

        private LogInView5Model viewModel;

        public LogInView5Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}