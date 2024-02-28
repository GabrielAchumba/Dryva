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
    public partial class PaymentView2 : ContentView
    {
        public PaymentView2()
        {
            InitializeComponent();
            ViewModel = new PaymentView2Model();
            BindingContext = ViewModel;
        }

        private PaymentView2Model viewModel;

        public PaymentView2Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
    }
}