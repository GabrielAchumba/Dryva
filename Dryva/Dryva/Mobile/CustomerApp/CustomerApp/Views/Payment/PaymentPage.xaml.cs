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
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();
            this.BindingContext = new PaymentPageViewModel(this.Navigation);
        }

        private void MonthlyModeClick(object sender, EventArgs e)
        {
            (this.BindingContext as PaymentPageViewModel).MonthlyModeAction();
        }
        private void WeeklyModeClick(object sender, EventArgs e)
        {
            (this.BindingContext as PaymentPageViewModel).WeeklyModeAction();
        }

    }
}