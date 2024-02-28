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
    public partial class PaymentView4 : ContentView
    {
        public PaymentView4()
        {
            InitializeComponent();
            ViewModel = new PaymentView4Model();
            BindingContext = ViewModel;
        }

        private PaymentView4Model viewModel;

        public PaymentView4Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}