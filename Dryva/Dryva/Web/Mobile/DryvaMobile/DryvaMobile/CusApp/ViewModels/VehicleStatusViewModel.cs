using CusApp.DTOs.Device;
using CusApp.DTOs.Driver;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CusApp.ViewModels
{
    public class VehicleStatusViewModel: ViewModelBase
    {
        public VehicleStatusViewModel()
        {

        }

        #region Fields and Properties

        #region OccupiedSeats
        private int occupiedSeats=8;

        public int OccupiedSeats
        {
            get { return occupiedSeats; }
            set { SetProperty(ref occupiedSeats, value); }
        }

        #endregion

        #region EmptySeats
        private int emptySeats=3;

        public int EmptySeats
        {
            get { return emptySeats; }
            set { SetProperty(ref emptySeats, value); }
        }

        #endregion

        #region PlateNumber
        private string plateNumber ="AK 2345 UY";

        public string PlateNumber
        {
            get { return plateNumber; }
            set { SetProperty(ref plateNumber, value); }
        }

        #endregion

        #endregion

        #region Methods

        public async Task<int> UpdateVehicleStatusDashBoard()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                //DeviceTrailDTO deviceTrailDTO = await App.Database.GetDeviceTrailDTOAsyncREST();
                //VehicleDTO vehicleDTO = await App.Database.GetVehicleDTOAsyncREST();


            }
            return 1;
        }

        public override string ToString()
        {
            return "VehicleStatusViewModel";
        }

        #endregion
    }
}
