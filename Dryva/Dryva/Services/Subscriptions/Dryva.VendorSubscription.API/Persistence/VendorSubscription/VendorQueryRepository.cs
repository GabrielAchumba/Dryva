using Dryva.VendorSubscription.API.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace Dryva.VendorSubscription.API.Persistence.VendorSubscription
{
    public class VendorQueryRepository : IVendorQueryRepository
    {

        private readonly string connectionString;
        const string Table = "VendorSubscription";

        public VendorQueryRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("VendorTransactionDbConnection");
        }

        public Task<IEnumerable<VendorSubscriptionDto>> GetVendorSubscriptionByIdAsync(Guid vendorId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"SELECT [SubscriptionId], [VendorId], [CreatedOn], [ModifiedOn], [RechargeCode], " +
                    $"[Amount], [DepleteAmount], [TransactionCode], [IsActive] FROM {Table}";
                return connection.QueryAsync<VendorSubscriptionDto>(query);
            }
        }
    }
}
