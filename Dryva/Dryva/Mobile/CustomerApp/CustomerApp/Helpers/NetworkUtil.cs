using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Helpers
{
    public class NetworkUtil
    {
        public static bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }
        public async static Task<bool> ValidateNetwork()
        {
            if (!IsConnected())
            {
                await App.Current.MainPage.DisplayAlert("Network Problem", "You do not have network connectivity.", "Ok");
                return false;
            }
            return true;
        }
    }
}
