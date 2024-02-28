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
    public partial class PaymentView1 : ContentView
    {
        public PaymentView1()
        {
            InitializeComponent();
            ViewModel = new PaymentView1Model();
            BindingContext = ViewModel;
        }

        private PaymentView1Model viewModel;

        public PaymentView1Model ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }


        //void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        //{
        //    var imageSender = (Image)sender;
        //    imageSender.Source= ImageSource.FromFile()
        //    // Do something
        //    // DisplayAlert("Alert", "Tap gesture recoganised", "OK");
        //}

        //<Image Source = "success.png" >
        //                            < Image.GestureRecognizers >
        //                                < TapGestureRecognizer
        //                                Tapped="OnTapGestureRecognizerTapped"  />
        //                            </Image.GestureRecognizers>
        //                        </Image>

    }
}