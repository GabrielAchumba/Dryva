using Dapper;
using Dryva.VendorSubscription.API.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Persistence.CustomerRecharge
{
    public class CustomerRechargeQueryRepository : ICustomerRechargeQueryRepository
    {
        private readonly string connectionString;
        const string Table = "CustomerSubscription";

        public CustomerRechargeQueryRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("VendorTransactionDbConnection");
        }

        public async Task<CustomerSubscriptionDto> GetCustomerSubscriptionById(Guid rechargeId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"SELECT [SubscriptionId], [VendorId], [CreatedOn], [Amount], [CustomerId], " +
                    $"[CardSerialNumber] FROM {Table} WHERE SubscriptionId = '{rechargeId}'";
                return await connection.QuerySingleOrDefaultAsync<CustomerSubscriptionDto>(query);

            }
        }

        public async Task<IEnumerable<CustomerSubscriptionDto>> GetCustomerSubscriptionByVendorIdAsync(Guid vendorId)
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                var query = $"SELECT [SubscriptionId], [VendorId], [CreatedOn], [Amount], [CustomerId], " +
                    $"[CardSerialNumber] FROM {Table} WHERE VendorId = '{vendorId}'";
                return await connection.QueryAsync<CustomerSubscriptionDto>(query);
            }
        }

        public async Task<IEnumerable<CustomerSubscriptionDto>> GetCustomerSubscriptionWithinDatesAsync(DateTimeOffset beginDate, DateTimeOffset endDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"SELECT [SubscriptionId], [VendorId], [CreatedOn], [Amount], [CustomerId], " +
                    $"[CardSerialNumber] FROM {Table} WHERE CreatedOn BETWEEN = '{beginDate}' AND '{endDate}'";
                return await connection.QueryAsync<CustomerSubscriptionDto>(query);
            }
        }
    }
}
