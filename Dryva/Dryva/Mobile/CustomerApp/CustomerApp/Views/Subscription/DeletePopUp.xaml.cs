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
    public partial class DeletePopUp : ContentView
    {
        public DeletePopUp()
        {
            InitializeComponent();
           
        }

        //private DeletePopUpModel viewModel;

        //public DeletePopUpModel ViewModel
        //{
        //    get { return viewModel; }
        //    set { viewModel = value; }
        //}
    }
}