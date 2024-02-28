using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;

namespace CustomerSubscription.API.Application.Queries
{
    public class GetSubscriptionsQuery : IRequest<IEnumerable<SubscriptionDto>>
    {
        public Guid CustomerId { get; }
        public long CardSerialNumber { get; }

        public GetSubscriptionsQuery(SubscriptionParameters subscriptionParameters)
        {
            CustomerId = subscriptionParameters.CustomerId;
            CardSerialNumber = subscriptionParameters.CardSerialNumber;
        }
    }
}
