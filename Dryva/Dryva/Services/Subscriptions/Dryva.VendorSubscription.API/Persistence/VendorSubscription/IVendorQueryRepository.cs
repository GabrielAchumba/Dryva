using Dryva.VendorSubscription.API.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Persistence
{
    public interface IVendorQueryRepository
    {
        Task<IEnumerable<VendorSubscriptionDto>> GetVendorSubscriptionByIdAsync(Guid vendorId);
    }
}
