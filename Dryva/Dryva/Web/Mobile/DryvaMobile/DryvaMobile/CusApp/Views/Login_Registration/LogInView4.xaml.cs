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
    public partial class LogInView4 : ContentView
    {
        public LogInView4()
        {
            InitializeComponent();
            ViewModel = new LogInView4Model();
            BindingContext = ViewModel;
        }

        private LogInView4Model viewModel;

        public LogInView4Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}