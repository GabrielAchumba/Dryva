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
    public partial class LogInView2 : ContentView
    {
        public LogInView2()
        {
            InitializeComponent();
            ViewModel = new LogInView2Model();
            BindingContext = ViewModel;
        }

        private LogInView2Model viewModel;

        public LogInView2Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}