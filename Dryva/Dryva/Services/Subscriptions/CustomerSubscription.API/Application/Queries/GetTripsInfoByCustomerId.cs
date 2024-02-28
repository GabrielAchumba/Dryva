using System;
using CustomerSubscription.API.Application.Dtos;
using MediatR;

namespace CustomerSubscription.API.Application.Queries {
    public class GetTripsInfoByCustomerId : IRequest<SubscriberTripsDetailDto> {
        
        public GetTripsInfoByCustomerId(Guid customerId) {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
        
    }
}