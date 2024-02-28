using AutoMapper;
using Dryva.VendorSubscription.API.Dtos;

namespace Dryva.VendorSubscription.API.Profiles
{
    public class VendorSubscriptionProfile : Profile
    {
        public VendorSubscriptionProfile()
        {
            CreateMap<VendorSubscriptionDto, Application.Models.VendorSubscription>().ReverseMap();
            CreateMap<NewVendorSubscriptionDto, Application.Models.VendorSubscription>().ReverseMap();
        }
    }
}

