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
    public partial class LogInView3 : ContentView
    {
        public LogInView3()
        {
            InitializeComponent();
            ViewModel = new LogInView3Model();
            BindingContext = ViewModel;
        }

        private LogInView3Model viewModel;

        public LogInView3Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}