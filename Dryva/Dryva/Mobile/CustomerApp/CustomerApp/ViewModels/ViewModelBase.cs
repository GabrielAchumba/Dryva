using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CustomerApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool indicatorIsVisibled;
        public bool IndicatorIsVisibled
        {
            get { return indicatorIsVisibled; }
            set { indicatorIsVisibled = value; this.RaisePropertyChanged(); }
        }
        private bool indicatorIsRunning;
        public bool IndicatorIsRunning
        {
            get { return indicatorIsRunning; }
            set { indicatorIsRunning = value; this.RaisePropertyChanged(); }
        }
        private bool isActionCommandEnabled = true;
        public bool IsActionCommandEnabled
        {
            get { return isActionCommandEnabled; }
            set { isActionCommandEnabled = value; this.RaisePropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value,
                                      [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        protected bool SetProperty<T>(ref T storage, T value,string ModelName,object ModelObject,
                                      [CallerMemberName] string propertyName = null)
        {
            Application.Current.Properties[ModelName] = ModelObject;

            if (Object.Equals(storage, value))
                return false;

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public virtual void NotBusy()
        {
            this.IndicatorIsVisibled = false;
            this.IndicatorIsRunning = false;
            this.IsActionCommandEnabled = true;
        }
        public virtual void Busy()
        {
            this.IndicatorIsVisibled = true;
            this.IndicatorIsRunning = true;
            this.IsActionCommandEnabled = false;
        }
    }
}
