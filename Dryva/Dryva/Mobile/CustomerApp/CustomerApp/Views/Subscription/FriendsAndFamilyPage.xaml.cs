﻿using CustomerApp.ViewModels;
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
    public partial class FriendsAndFamilyPage : ContentPage
    {
        public FriendsAndFamilyPage()
        {
            InitializeComponent();
           
        }

        //private FriendsAndFamilyPageModel viewModel;

        //public FriendsAndFamilyPageModel ViewModel
        //{
        //    get { return viewModel; }
        //    set { viewModel = value; }
        //}
    }
}