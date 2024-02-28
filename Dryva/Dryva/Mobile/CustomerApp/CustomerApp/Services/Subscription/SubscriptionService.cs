using CustomerApp.DTOs.Customer;
using CustomerApp.DTOs.Financial;
using CustomerApp.Models;
using CustomerApp.Services.ServiceUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebViewPG.Forms;
using Xamarin.Forms;

namespace CustomerApp.Services
{
    internal class SubscriptionService : ISubscriptionService
    {
        private string ControllerName = "CustomerSubscription";

        public async Task<EnvelopeData<PaymentSubscriptionDTO>> SaveSubscriptionAsync(PaymentSubscriptionDTO item)
        {
            if (item == null)
                return new Envelope<PaymentSubscriptionDTO>().ReportError("Object can not be null");

            item.Id = Guid.NewGuid();
            return await APIHelper.InsertData<PaymentSubscriptionDTO>(item, ControllerName, "subscribe");
        }

        public async Task<EnvelopeData<SubscriptionDTO>> GetSusbcriptions(Guid customerId)
        {
            return await APIHelper.GetData<SubscriptionDTO>(ControllerName, $"{customerId}/trips");
        }


    }
}
