using CustomerSubscription.API.Application.Dtos;
using MediatR;
using System;

namespace CustomerSubscription.API.Application.Commands
{
    public class ShareSubscriptionUnitCommand : IRequest<SubscriptionDto>
    {
        public ShareSubscriptionUnitCommand(Guid customerId, Guid recipientId, int unit)
        {
            CustomerId = customerId;
            RecipientId = recipientId;
            Unit = unit;
        }

        public Guid CustomerId { get; set; }

        public Guid RecipientId { get; set; }

        public int Unit { get; set; }
    }
}
