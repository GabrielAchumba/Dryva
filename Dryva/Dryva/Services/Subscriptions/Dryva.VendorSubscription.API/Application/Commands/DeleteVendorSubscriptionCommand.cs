using MediatR;
using System;

namespace Dryva.VendorSubscription.API.Application.Commands
{
    public class DeleteVendorSubscriptionCommand : IRequest<int>
    {
        public Guid VendorId { get; set; }

        public DeleteVendorSubscriptionCommand(Guid vendorId)
        {
            VendorId = vendorId;
        }
    }
}
