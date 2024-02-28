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
    public partial class PaymentView3 : ContentView
    {
        public PaymentView3()
        {
            InitializeComponent();
            ViewModel = new PaymentView3Model();
            BindingContext = ViewModel;
        }

        private PaymentView3Model viewModel;

        public PaymentView3Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}