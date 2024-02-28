using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Persistence
{
    public interface IVendorCommandRepository
    {
        Task<Application.Models.VendorSubscription> AddSubscriptionAsync(Application.Models.VendorSubscription vendorSubscription);
    }
}
