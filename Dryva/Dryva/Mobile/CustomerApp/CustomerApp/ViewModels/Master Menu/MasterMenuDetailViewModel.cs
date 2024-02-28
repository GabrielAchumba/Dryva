using CustomerApp.DTOs.Device;
using CustomerApp.DTOs.Vehicle;
using CustomerApp.Models;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CustomerApp.ViewModels
{
    public class MasterMenuDetailViewModel: ViewModelBase
    {
        public MasterMenuDetailViewModel()
        {
            LoadRouteList();
            LoadDeviceList();
            _locations = new ObservableCollection<Location>();

            
            int counter = 0;
            Latitude = DeviceList[0].Latitude;
            Longitude = DeviceList[0].Longitude;
            int tim = 5;
            foreach (var item in DeviceList)
            {
                tim = tim + 1;
                string Description = "Vehicle Plate Number : AK 387 UR" + "\t"
                    + "Estimated Time of Arrival: " + tim.ToString() + " minutes";
                counter++;
                _myPosition = new Position(item.Latitude, item.Longitude);
                Location Location_i = new Location(RoutesList[0].RouteName, Description, _myPosition);
                _locations.Add(Location_i);
            }
        }

        #region Fields and Properties

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;


        private Position _myPosition;// = new Position(-37.8141, 144.9633);
        public Position MyPosition
        {
            get { return _myPosition; }
            set { SetProperty(ref _myPosition, value); }
        }




        #region RoutesList
        private IList<RouteDTO> routesList;

        public IList<RouteDTO> RoutesList
        {
            get { return routesList; }
            set { SetProperty(ref routesList, value); }
        }

        #endregion

        #region SelectedRoute
        private RouteDTO selectedRoute;

        public RouteDTO SelectedRoute
        {
            get { return selectedRoute; }
            set { SetProperty(ref selectedRoute, value); }
        }

        #endregion

        #region DeviceList
        private IList<DeviceTrailDTO> deviceList;

        public IList<DeviceTrailDTO> DeviceList
        {
            get { return deviceList; }
            set { SetProperty(ref deviceList, value); }
        }

        #endregion




        #endregion

        #region Events and Methods

        private void LoadRouteList()
        {
            RoutesList = new List<RouteDTO>()
            {
                new RouteDTO()
                {
                    RouteName="Ikot Ekpene Road"
                },
                new RouteDTO()
                {
                    RouteName="Atiku Road"
                },
                new RouteDTO()
                {
                    RouteName="IBB Road"
                },
                new RouteDTO()
                {
                    RouteName="Aka Road"
                }
            };
        }

        private void LoadDeviceList()
        {
            DeviceList = new List<DeviceTrailDTO>()
            {
                new DeviceTrailDTO()
                {
                    Latitude=5.04432,
                    Longitude=7.900775
                },
                new DeviceTrailDTO()
                {
                    Latitude=5.042109,
                    Longitude=7.905416
                },
                new DeviceTrailDTO()
                {
                    Latitude=5.039715,
                    Longitude=7.914167
                },
                new DeviceTrailDTO()
                {
                    Latitude=5.036124,
                    Longitude=7.923433
                }
            };
        }



        public override string ToString()
        {
            return "NVehicleViewModel";
        }
        #endregion


    }
}
