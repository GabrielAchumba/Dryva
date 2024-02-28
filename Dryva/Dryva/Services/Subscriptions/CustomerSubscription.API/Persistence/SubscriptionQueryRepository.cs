using CustomerSubscription.API.Application.Dtos;
using Dapper;
using Dryva.Utitlties.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Persistence
{
    public partial class SubscriptionQueryRepository : ISubscriptionQueryRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<SubscriptionQueryRepository> _logger;

        public SubscriptionQueryRepository(IConfiguration configuration, ILogger<SubscriptionQueryRepository> logger) {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("SubscriptionDbConnection");
        }

        public async Task<SubscriptionDto> GetSubscriptionByDateAsync(Guid customerId, DateTimeOffset date)
        {
            _logger.LogInformation("Called into GetSubscriptionByDateAsync");
            
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var command = $"SELECT [SubscriptionDate], [Amount], [Unit] FROM Subscriptions WHERE customerId = '{customerId}' AND SubscriptionDate = {date}";
            var subscriptionDto = await connection.QuerySingleOrDefaultAsync<SubscriptionDto>(command);
            return subscriptionDto;
        }

        public async Task<SubscriptionDto> GetSubscriptionsBySubscriptionIdAsync(Guid subscriptionId) {
            _logger.LogInformation("Called into GetSubscriptionsBySubscriptionIdAsync");
            
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            //var command = $"SELECT [SubscriptionId], [CustomerId], [CardSerialNumber], [Amount] FROM Subscriptions WHERE subscriptionId = '{subscriptionId}'";
            var query = $"SELECT [SubscriptionId], [CreatedOn], [ModifiedOn], [TransactionCode], " +
                        $"[IsActive], [RechargeCode], [DepleteAmount] as Amount, [CustomerId], [CardSerialNumber] FROM Subscriptions WHERE subscriptionId = '{subscriptionId}'";
            var subscriptionDto = await connection.QuerySingleOrDefaultAsync<SubscriptionDto>(query);
            return subscriptionDto;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetSubscriptionsByCustomerIdAsync(Guid customerId)
        {
            _logger.LogInformation($"Called into GetSubscriptionsByCustomerIdAsync for customer {customerId}", customerId);
            
            return await GetSubscriptionsAsync($"customerId = '{customerId}'");
        }

        public async Task<IEnumerable<SubscriptionDto>> GetSubscriptionsByCardNumberAsync(long cardSerialNumber)
        {
            _logger.LogInformation("Called into GetSubscriptionsByCardNumberAsync for card {cardNumber}", cardSerialNumber);
            
            return await GetSubscriptionsAsync($"cardSerialNumber = {cardSerialNumber}");
        }

        public async Task<IEnumerable<SubscriptionDto>> GetActiveSubscriptionByCustomerIdAsync(Guid customerId)
        {
            _logger.LogInformation("Called into GetActiveSubscriptionByCustomerIdAsync for customer {customer}", customerId);
            
            return await GetActiveSubscriptionAsync($"CustomerId = '{customerId}'");
        }

        public async Task<SubscriptionDto> GetActiveSubscriptionByCardSerialNumberAsync(long cardSerialNumber) {
            _logger.LogInformation("Called into GetActiveSubscriptionByCardSerialNumberAsync for card {cardNumber}", cardSerialNumber);
            
            await using var connection = new SqlConnection(_connectionString);
            var query = "SELECT TOP (1) [SubscriptionId], [CreatedOn], [ModifiedOn], [TransactionCode], " +
                        "[IsActive], [RechargeCode], [Amount], [DepleteAmount], [CustomerId], [CardSerialNumber] FROM Subscriptions" +
                        $" WHERE CardSerialNumber = {cardSerialNumber} ORDER BY CreatedOn DESC";
            return await connection.QuerySingleAsync<SubscriptionDto>(query);
        }

        public async Task<IEnumerable<SubscriberDto>> GetSubscribersByDateDescAsync()
        {
            _logger.LogInformation("Called into GetSubscribersByDateAsync");
            
            var query = $"SELECT DISTINCT [CustomerId], [CardSerialNumber] FROM Subscriptions";
            await using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<SubscriberDto>(query);
        }

        public async Task<SubscriberTripsDetailDto> GetDepleteAmount(Guid customerId) {
            _logger.LogInformation("Called into GetDepleteAmount for customer {customerId}", customerId);
            
            var query = $"SELECT TOP 1 [CardSerialNumber], [CustomerId], [DepleteAmount] FROM Subscriptions WHERE [CustomerId] = '{customerId}'" +
                        " ORDER BY CreatedOn DESC";
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<SubscriberTripsDetailDto>(query);
        }
    }
}
