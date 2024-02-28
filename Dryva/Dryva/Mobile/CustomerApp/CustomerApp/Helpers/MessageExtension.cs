using CustomerApp.Controls.Alert;
using CustomerApp.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerApp.Helpers
{
    public static class MessageExtension
    {
        public async static Task DisplayMessage(this INavigation navigation, ButtonTypeEnum btnTypeEnum, IconTypeEnum iconType,
              string pageTitle, string msgtitle, params string[] msgs)
        {
            var page = new AlertControl(btnTypeEnum, iconType, pageTitle, msgtitle, msgs);
            await navigation.PushModalAsync(page, false);
            //await navigation.PopAsync().ConfigureAwait(true);            
        }
    }
}
