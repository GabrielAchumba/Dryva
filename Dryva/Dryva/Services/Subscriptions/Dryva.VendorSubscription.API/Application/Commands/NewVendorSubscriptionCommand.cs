using Dryva.VendorSubscription.API.Dtos;
using MediatR;
using System;

namespace Dryva.VendorSubscription.API.Application.Commands
{
    public class NewVendorSubscriptionCommand : IRequest<VendorSubscriptionDto>
    {
        public Guid VendorId { get; }

        public NewVendorSubscriptionDto NewVendorSubscriptionDto { get; }

        public NewVendorSubscriptionCommand(Guid vendorId, NewVendorSubscriptionDto vendorSubscriptionDto)
        {
            VendorId = vendorId;
            NewVendorSubscriptionDto = vendorSubscriptionDto;
        }
    }
}
