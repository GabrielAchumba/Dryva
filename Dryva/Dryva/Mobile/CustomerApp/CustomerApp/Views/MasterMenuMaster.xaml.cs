using CustomerApp.Helpers;
using CustomerApp.Models;
using CustomerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenuMaster : ContentPage
    {
        public MasterMenuMaster()
        {
            InitializeComponent();
            this.BindingContext = new MasterMenuMasterViewModel(this.Navigation);
            this.LoadImage();
        }

        private void LoadImage()
        {
            var vm = this.BindingContext as MasterMenuMasterViewModel;
            if (vm.Photo != null)
                this.imgPix.Source = ImageUtil.GetImageSource(vm.Photo);
        }

    }

}