using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using CustomerSubscription.API.Application.Models;
using CustomerSubscription.API.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Persistence
{
    public class SubscriptionCommandRepository : ISubscriptionCommandRepository
    {
        private readonly SubscriptionDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SubscriptionCommandRepository> _logger;

        public SubscriptionCommandRepository(IConfiguration configuration, SubscriptionDbContext subscriptionDbContext, ILogger<SubscriptionCommandRepository> logger)
        {
            _dbContext = subscriptionDbContext;
            _logger = logger;
            _configuration = configuration;
        }

        public async void AddSubscription(Subscription subscription)
        {
            _logger.LogInformation("Called into AddSubscription");
            
            await _dbContext.Subscriptions.AddAsync(subscription);
        }

        public async Task<Subscription> Clockin(long cardSerialNumber)
        {
            _logger.LogInformation("Called into Clock-in for {cardNumber}", cardSerialNumber);
            
            var subscription = _dbContext.Subscriptions.Where(s => s.CardSerialNumber == cardSerialNumber)
                .OrderByDescending(x => x.CreatedOn).FirstOrDefault();

            if (subscription != null) {
                subscription.DepleteAmount -= _configuration.GetValue<int>("ChargePerTrip");
                _dbContext.Subscriptions.Update(subscription);
                await _dbContext.SaveChangesAsync();
            } else {
                _logger.LogError("Could not find card with serial number {serialNumber}", cardSerialNumber);
            }

            return subscription;
        }

        public async Task<int> SaveAsync()
        {
            _logger.LogInformation("Called into  SaveAsync");
            return await _dbContext.SaveChangesAsync();
        }

        public Task<Subscription> ShareUnit(Guid customerId, Guid recipientId, int unit)
        {
            return null;
        }
    }
}
