using AutoMapper;
using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Models;

namespace CustomerSubscription.API.Profiles
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDto>().ReverseMap();
            CreateMap<NewSubscriptionDto, Subscription>().ReverseMap();
        }
    }
}
