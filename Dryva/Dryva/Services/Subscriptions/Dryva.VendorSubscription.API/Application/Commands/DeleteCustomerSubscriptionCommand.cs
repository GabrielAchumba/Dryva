using MediatR;
using System;

namespace Dryva.VendorSubscription.API.Application.Commands
{
    public class DeleteCustomerSubscriptionCommand : IRequest<int>
    {

        public Guid RechargeId { get; }

        public DeleteCustomerSubscriptionCommand(Guid rechargeId)
        {
            RechargeId = rechargeId;
        }
    }
}
