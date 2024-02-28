using CustomerSubscription.API.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace CustomerSubscription.API.Application.Queries
{
    public class GetActiveSubscriptionByCustomerIdQuery : IRequest<IEnumerable<SubscriptionDto>>
    {
        public Guid CustomerId { get; }

        public GetActiveSubscriptionByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
