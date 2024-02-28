using CustomerApp.DTOs.Customer;
using CustomerApp.DTOs.Device;
using CustomerApp.DTOs.Driver;
using CustomerApp.DTOs.Financial;
using CustomerApp.DTOs.MapsDTO;
using CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Services
{
    public interface ISubscriptionService
    {
        Task<EnvelopeData<PaymentSubscriptionDTO>> SaveSubscriptionAsync(PaymentSubscriptionDTO item);
        Task<EnvelopeData<SubscriptionDTO>> GetSusbcriptions(Guid customerId);
    }
}
