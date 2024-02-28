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
    public partial class PaymentPage1 : ContentPage
    {
        public PaymentPage1()
        {
            InitializeComponent();
            this.BindingContext = new PaymentPage1ViewModel(this.Navigation);
        }

        private void DebitCardClick(object sender, EventArgs e)
        {
            (this.BindingContext as PaymentPage1ViewModel).DebitCardAction();
        }
        private void BankDraftClick(object sender, EventArgs e)
        {
            (this.BindingContext as PaymentPage1ViewModel).BankDraftAction();
        }

    }
}