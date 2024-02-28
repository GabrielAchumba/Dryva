using Dryva.VendorSubscription.API.Infrastructure;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Persistence.VendorSubscription
{
    public class VendorCommandRepository : IVendorCommandRepository
    {
        private readonly VendorDbContext dbContext;

        public VendorCommandRepository(VendorDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Application.Models.VendorSubscription> AddSubscriptionAsync(Application.Models.VendorSubscription vendorSubscription)
        {
            await dbContext.VendorSubscription.AddAsync(vendorSubscription);
            await dbContext.SaveChangesAsync();
            return vendorSubscription;
        }
    }
}
