using Dryva.VendorSubscription.API.Dtos;
using MediatR;
using System;

namespace Dryva.VendorSubscription.API.Application.Commands
{
    public class UpdateVendorSubscriptionCommand : IRequest<VendorSubscriptionDto>
    {
        public Guid VendorId { get; set; }

        public VendorSubscriptionDto VendorSubscriptionDto { get; set; }

        public UpdateVendorSubscriptionCommand(Guid vendorId, VendorSubscriptionDto vendorSubscriptionDto)
        {
            VendorId = vendorId;
            VendorSubscriptionDto = vendorSubscriptionDto;
        }
    }
}
