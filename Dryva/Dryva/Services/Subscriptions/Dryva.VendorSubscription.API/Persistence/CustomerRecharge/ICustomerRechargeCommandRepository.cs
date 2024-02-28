using System;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Persistence.CustomerRecharge
{
    public interface ICustomerRechargeCommandRepository
    {
        Task<Application.Models.CustomerSubscription> AddSubscriptionAsync(Application.Models.CustomerSubscription customerRecharge);
        
        Task<int> UpdateSubscription(Application.Models.CustomerSubscription subscription);
        
        Task<int> DeleteCustomerRechargeAsync(Guid rechargeId);

    }
}
