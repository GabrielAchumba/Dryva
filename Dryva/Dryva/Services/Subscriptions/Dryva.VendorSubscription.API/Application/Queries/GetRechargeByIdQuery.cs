using Dryva.VendorSubscription.API.Dtos;
using MediatR;
using System;

namespace Dryva.VendorSubscription.API.Application.Queries
{
    public class GetSubscriptionByIdQuery : IRequest<CustomerSubscriptionDto>
    {
        public Guid RechargeId { get; set; }

        public GetSubscriptionByIdQuery(Guid rechargeId)
        {
            RechargeId = rechargeId;
        }
    }
}
