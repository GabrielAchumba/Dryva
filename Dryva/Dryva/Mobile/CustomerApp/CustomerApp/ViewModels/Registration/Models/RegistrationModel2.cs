using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomerApp.ViewModels.Registration.Models
{
    public class RegistrationModel2 : ViewModelBase
    {
        private DateTime birthDate= DateTime.Now;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; this.RaisePropertyChanged(); }
        }

        private string state;
        public string State
        {
            get { return state; }
            set { state = value; this.RaisePropertyChanged(); }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; this.RaisePropertyChanged(); }
        }

        public byte[] Photograph { get; set; }

        private ImageSource pixSource;
        public ImageSource PixSource
        {
            get { return pixSource; }
            set { pixSource = value; this.RaisePropertyChanged(); }
        }

    }
}
