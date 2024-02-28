using AutoMapper;
using Dryva.Security.DTOs;
using Dryva.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.Helpers
{
    public class ProfileHelper : Profile
    {
        public ProfileHelper()
        {
            CreateMap<RegisterUserDTO, AppUser>().ReverseMap();
        }
    }
}
