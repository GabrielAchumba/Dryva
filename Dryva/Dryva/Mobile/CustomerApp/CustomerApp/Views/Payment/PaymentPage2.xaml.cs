using CustomerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage2 : ContentPage
    {
        public PaymentPage2()
        {
            InitializeComponent();
            this.BindingContext = new PaymentPage2ViewModel(this.Navigation);

        }
    }
}