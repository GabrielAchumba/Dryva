using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CusApp.DTOs.Customer;
using CusApp.DTOs.Device;
using CusApp.DTOs.Driver;
using CusApp.DTOs.Financial;
using CusApp.DTOs.MapsDTO;
using CusApp.Helpers;
using CusApp.Models;
using SQLite;

namespace CusApp.Data
{
    public class DryvaCustomerDatabase
    {
        IRestService restService;
        public DryvaCustomerDatabase(IRestService service)
        {
            restService = service;
            InitializeAsync().SafeFireAndForget(false);
        }

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RegistrationItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(RegistrationItem)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(WalletItem)).ConfigureAwait(false);

                    initialized = true;
                }
            }
        }


        #region Create Item
        public Task<RegistrationItem> GetRegistrationItemAsync()
        {
            return Database.Table<RegistrationItem>().FirstOrDefaultAsync();
        }

        public Task<WalletItem> GetWalletItemAsync()
        {
            return Database.Table<WalletItem>().FirstOrDefaultAsync();
        }

        public Task<List<WalletItem>> GetWalletItemsAsync()
        {
            return Database.Table<WalletItem>().ToListAsync();
        }

        public Task<RegistrationDTO> GetRegistrationDTOAsyncREST()
        {
            return restService.RefreshRegistrationDTOAsync();
        }

        public Task<List<WalletItem>> GetWalletItemsAsyncREST()
        {
            return restService.RefreshWalletItemsAsync();
        }

        public Task<MapAxisDTO> GetMapAxisDTOAsyncREST()
        {
            return restService.RefreshMapAxisDTOAsync();
        }

        public Task<DeviceTrailDTO> GetDeviceTrailDTOAsyncREST()
        {
            return restService.RefreshDeviceTrailDTOAsync();
        }

        public Task<VehicleDTO> GetVehicleDTOAsyncREST()
        {
            return restService.RefreshVehicleDTOAsync();
        }

        public Task<SubscriptionDTO> GetSubscriptionDTOAsyncREST()
        {
            return restService.RefreshSubscriptionDTOAsync();
        }

        public Task<List<SubscriptionDTO>> GetSubscriptionDTOListAsyncREST()
        {
            return restService.RefreshSubscriptionDTOListAsync();
        }

        #endregion


        #region Save Item

        public Task<int> SaveRegistrationItemAsync(RegistrationItem item)
        {
            //if (item.ID != 0)
            //{
            //    return Database.UpdateAsync(item);
            //}
            //else
            //{
            //    return Database.InsertAsync(item);
            //}

            return Database.InsertAsync(item);
        }

        public Task<int> SaveWalletItemAsync(WalletItem item)
        {
            //if (item.ID != 0)
            //{
            //    return Database.UpdateAsync(item);
            //}
            //else
            //{
            //    return Database.InsertAsync(item);
            //}

            return Database.InsertAsync(item);
        }

        public Task SaveRegistrationDTOAsync(RegistrationDTO item)
        {
            return restService.SaveRegistrationDTOAsync(item);
        }

        public Task SaveWalletItemAsyncREST(WalletItem item)
        {
            return restService.SaveWalletItemsAsync(item);
        }

        public Task SaveMapAxisDTOAsync(MapAxisDTO item)
        {
            return restService.SaveMapAxisDTOAsync(item);
        }

        public Task SaveDeviceTrailDTOAsync(DeviceTrailDTO item)
        {
            return restService.SaveDeviceTrailDTOAsync(item);
        }

        public Task SaveSubscriptionDTOAsync(SubscriptionDTO item)
        {
            return restService.SaveSubscriptionDTOAsync(item);
        }

        public Task SaveShareUnitDTOListAsync(List<ShareUnitDTO> items)
        {
            return restService.SaveShareUnitDTOListAsync(items);
        }

        #endregion



    }
}