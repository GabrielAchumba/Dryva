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
    public partial class LogInView1 : ContentView
    {
        public LogInView1()
        {
            InitializeComponent();
            ViewModel = new LogInView1Model();
            BindingContext = ViewModel;
        }

        private LogInView1Model viewModel;

        public LogInView1Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}