using CustomerSubscription.API.Application.Dtos;
using Dapper;
using Dryva.Utitlties.Sql;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Persistence
{
    public partial class SubscriptionQueryRepository
    {
        private async Task<IEnumerable<SubscriptionDto>> GetSubscriptionsAsync(string whereCondition) {
            _logger.LogInformation("Called into GetSubscriptionsAsync for clause {whereClause}", whereCondition);
            
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT [subscriptionId], [CreatedOn], [ModifiedOn], [TransactionCode], [IsActive], [RechargeCode], " +
                        "[DepleteAmount] As [Amount], [CustomerId], [CardSerialNumber] FROM Subscriptions " +
                        $" WHERE {whereCondition}";

            return await connection.QueryAsync<SubscriptionDto>(query);
        }

        private async Task<IEnumerable<SubscriptionDto>> GetActiveSubscriptionAsync(string whereClause) {
            _logger.LogInformation("Called into GetActiveSubscription using for clause {clause}", whereClause);
            
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
				
            var query = "SELECT [subscriptionId], [CreatedOn], [ModifiedOn], [TransactionCode], [IsActive], [RechargeCode], " +
                        "[DepleteAmount] As [Amount], [CustomerId], [CardSerialNumber] FROM Subscriptions" +
                        $" WHERE {whereClause} ORDER BY [CreatedOn] Desc";

            return await connection.QueryAsync<SubscriptionDto>(query);
        }
    }
}
