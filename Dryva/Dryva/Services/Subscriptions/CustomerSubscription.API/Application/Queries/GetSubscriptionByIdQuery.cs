using CustomerSubscription.API.Application.Dtos;
using MediatR;
using System;

namespace CustomerSubscription.API.Application.Queries
{
    public class GetSubscriptionByIdQuery : IRequest<SubscriptionDto>
    {
        public Guid SubscriptionId { get; }

        public GetSubscriptionByIdQuery(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
