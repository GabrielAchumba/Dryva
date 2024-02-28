using AutoMapper;
using Dryva.VendorSubscription.API.Application.Models;
using Dryva.VendorSubscription.API.Dtos;

namespace Dryva.VendorSubscription.API.Profiles
{
    public class CustomerSubscriptionProfile : Profile
    {
        public CustomerSubscriptionProfile()
        {
            CreateMap<CustomerSubscriptionDto, CustomerSubscription>().ReverseMap();
            CreateMap<CustomerSubscriptionUpdateDto, CustomerSubscription>().ReverseMap();
            CreateMap<CustomerSubscriptionUpdateDto, CustomerSubscriptionDto>().ReverseMap();
        }
    }
}
