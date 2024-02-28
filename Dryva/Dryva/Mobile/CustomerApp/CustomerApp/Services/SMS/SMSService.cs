using CustomerApp.DTOs.Customer;
using CustomerApp.DTOs.Financial;
using CustomerApp.Models;
using CustomerApp.Services.ServiceUtils;
using Dryva.Utilities.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Services
{
    internal class SMSService : ISMSService
    {
        public SMSService()
        {
            App.Current.Properties["SMS_Email"] = "enewizard@yahoo.com";
            App.Current.Properties["SMS_Sender"] = "DRYVA";
            App.Current.Properties["SMS_Password"] = "Dryva@Smart0";
        }

        public int? SendSMS(string message, string phoneNumber)
        {
            try
            {
                string email = App.Current.Properties["SMS_Email"].ToString();
                string subAccount = App.Current.Properties["SMS_Sender"].ToString();
                string password = App.Current.Properties["SMS_Password"].ToString();

                var smsService = new SMSLive247Service();
                if (smsService.Login(email, subAccount, password))
                {
                    var result = smsService.SendMessage(message, subAccount, phoneNumber);
                    return result;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
