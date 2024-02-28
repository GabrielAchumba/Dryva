using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.DTOs.Customer;
using CustomerApp.DTOs.Device;
using CustomerApp.DTOs.Driver;
using CustomerApp.DTOs.Financial;
using CustomerApp.DTOs.MapsDTO;
using CustomerApp.Helpers;
using CustomerApp.Models;
using SQLite;

namespace CustomerApp.Services
{
    public class DryvaCustomerDatabase
    {

        public ISMSService SMSService { get; }
        public ICustomerService Customer { get; }
        public ISubscriptionService Subscription { get; }
        public DryvaCustomerDatabase()
        {
            this.SMSService = new SMSService();
            this.Customer = new CustomerService();
            this.Subscription = new SubscriptionService();
            InitializeAsync().SafeFireAndForget(false);
        }

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        public SQLiteAsyncConnection LocalDb => lazyInitializer.Value;
        static bool initialized = false;

        

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!LocalDb.TableMappings.Any(m => m.MappedType.Name == typeof(CustomerInfo).Name))
                {
                    //await LocalDb.CreateTablesAsync(CreateFlags.None, typeof(WalletItem)).ConfigureAwait(false);
                    await LocalDb.CreateTablesAsync(CreateFlags.None, typeof(CustomerInfo)).ConfigureAwait(false);

                    initialized = true;
                }
            }
        }


    }
}