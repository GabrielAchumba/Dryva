using CustomerSubscription.API.Application.Models;
using System;
using System.Threading.Tasks;

namespace CustomerSubscription.API.Persistence
{
    public interface ISubscriptionCommandRepository
    {
        void AddSubscription(Subscription subscription);

        Task<int> SaveAsync();

        Task<Subscription> ShareUnit(Guid customerId, Guid recipientId, int unit);

        Task<Subscription> Clockin(long cardSerialNumber);
    }
}
