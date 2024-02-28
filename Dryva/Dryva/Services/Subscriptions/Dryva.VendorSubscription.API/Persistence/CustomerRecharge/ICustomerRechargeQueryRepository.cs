using Dryva.VendorSubscription.API.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Persistence.CustomerRecharge
{
    public interface ICustomerRechargeQueryRepository
    {
        Task<CustomerSubscriptionDto> GetCustomerSubscriptionById(Guid subscriptionId);

        Task<IEnumerable<CustomerSubscriptionDto>> GetCustomerSubscriptionByVendorIdAsync(Guid vendorId);

        Task<IEnumerable<CustomerSubscriptionDto>> GetCustomerSubscriptionWithinDatesAsync(DateTimeOffset beginDate, DateTimeOffset endDate);
    }
}
