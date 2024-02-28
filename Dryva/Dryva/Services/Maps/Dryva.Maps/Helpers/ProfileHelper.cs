using AutoMapper;
using Dryva.Maps.DTOs;
using Dryva.Maps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Helpers
{
    public class ProfileHelper : Profile
    {
        public ProfileHelper()
        {
            CreateMap<MapAxis, MapAxisDTO>().ReverseMap();
            CreateMap<MapAxis, NewMapAxisDTO>().ReverseMap();
        }
    }
}
