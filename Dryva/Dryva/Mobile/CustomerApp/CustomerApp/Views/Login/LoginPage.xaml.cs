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
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel ViewModel { get; }
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = ViewModel = new LoginViewModel(this.Navigation);
        }
        private void ForgotPasswordClick(object sender, System.EventArgs e)
        {
            ViewModel.ForgotPasswordAction();
        }
    }
}