using CustomerSubscription.API.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSubscription.API.Persistence
{
    public interface ISubscriptionQueryRepository
    {
        Task<IEnumerable<SubscriptionDto>> GetSubscriptionsByCustomerIdAsync(Guid customerId);

        Task<IEnumerable<SubscriptionDto>> GetSubscriptionsByCardNumberAsync(long cardSerialNumber);

        Task<SubscriptionDto> GetSubscriptionByDateAsync(Guid customerId, DateTimeOffset date);

        Task<SubscriptionDto> GetSubscriptionsBySubscriptionIdAsync(Guid subscriptionId);

        Task<IEnumerable<SubscriptionDto>> GetActiveSubscriptionByCustomerIdAsync(Guid customerId);

        Task<SubscriptionDto> GetActiveSubscriptionByCardSerialNumberAsync(long cardNumber);
        
        Task<IEnumerable<SubscriberDto>> GetSubscribersByDateDescAsync();
        
        Task<SubscriberTripsDetailDto> GetDepleteAmount(Guid customerId);
    }
}
