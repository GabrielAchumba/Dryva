using CusApp.DTOs.Customer;
using CusApp.DTOs.Device;
using CusApp.DTOs.Driver;
using CusApp.DTOs.Financial;
using CusApp.DTOs.MapsDTO;
using CusApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CusApp.Data
{
    public interface IRestService
    {
        #region Read from APIs
        Task<RegistrationDTO> RefreshRegistrationDTOAsync();
        Task<List<WalletItem>> RefreshWalletItemsAsync();

        Task<MapAxisDTO> RefreshMapAxisDTOAsync();

        Task<DeviceTrailDTO> RefreshDeviceTrailDTOAsync();

        Task<VehicleDTO> RefreshVehicleDTOAsync();

        Task<SubscriptionDTO> RefreshSubscriptionDTOAsync();

        Task<List<SubscriptionDTO>> RefreshSubscriptionDTOListAsync();


        #endregion

        #region Write to API

        Task SaveRegistrationDTOAsync(RegistrationDTO item);
        Task SaveWalletItemsAsync(WalletItem item);

        Task SaveMapAxisDTOAsync(MapAxisDTO item);

        Task SaveDeviceTrailDTOAsync(DeviceTrailDTO item);

        Task SaveSubscriptionDTOAsync(SubscriptionDTO item);

        Task SaveShareUnitDTOListAsync(List<ShareUnitDTO> items);

      

        #endregion




    }
}
