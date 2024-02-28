using Dryva.VendorSubscription.API.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dryva.VendorSubscription.API.Persistence.CustomerRecharge
{
    public class CustomerRechargeCommandRepository : ICustomerRechargeCommandRepository
    {

        private readonly VendorDbContext dbContext;

        public CustomerRechargeCommandRepository(VendorDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Application.Models.CustomerSubscription> AddSubscriptionAsync(Application.Models.CustomerSubscription customerRecharge)
        {
            await dbContext.CustomerSubscription.AddAsync(customerRecharge);
            await dbContext.SaveChangesAsync();
            return customerRecharge;
        }

        public async Task<int> DeleteCustomerRechargeAsync(Guid subscriptionId)
        {
            var customerRecharge = dbContext.CustomerSubscription.FirstOrDefault(x => x.SubscriptionId == subscriptionId);
            dbContext.CustomerSubscription.Remove(customerRecharge);
            return await dbContext.SaveChangesAsync();
        }

        public VendorDbContext GetDbContext()
        {
            return dbContext;
        }

        public async Task<int> UpdateSubscription(Application.Models.CustomerSubscription customerSubscription)
        {
            dbContext.CustomerSubscription.Update(customerSubscription);
            return await dbContext.SaveChangesAsync();
        }
    }
}
