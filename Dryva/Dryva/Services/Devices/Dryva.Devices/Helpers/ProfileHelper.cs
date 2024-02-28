using AutoMapper;
using Dryva.Devices.DTOs;
using Dryva.Devices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Helpers
{
    public class ProfileHelper : Profile
    {
        public ProfileHelper()
        {
            CreateMap<Device, DeviceDTO>().ReverseMap();
            CreateMap<Device, NewDeviceDTO>().ReverseMap();

            CreateMap<Device, DetailsDTO>().ReverseMap();
            CreateMap<DeviceTrail, DeviceTrailDTO>().ReverseMap();
            CreateMap<EntryTransitLog, EntryTransitLogDTO>().ReverseMap();
            CreateMap<ExitTransitLog, ExitTransitLogDTO>().ReverseMap();
            CreateMap<TransitLogDTO, GPSInfo>().ReverseMap();
            CreateMap<EntryTransitLogDTO, GPSInfo>().ReverseMap();
            CreateMap<ExitTransitLogDTO, GPSInfo>().ReverseMap();

            CreateMap<RouteDTO, Route>().ReverseMap();
            CreateMap<NewRouteDTO, Route>().ReverseMap();
        }
    }
}
