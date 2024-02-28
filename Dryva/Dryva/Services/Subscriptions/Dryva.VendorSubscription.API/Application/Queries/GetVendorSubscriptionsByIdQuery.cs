using Dryva.VendorSubscription.API.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Dryva.VendorSubscription.API.Application.Queries
{
    public class GetVendorSubscriptionsByIdQuery : IRequest<IEnumerable<VendorSubscriptionDto>>
    {

        public Guid VendorId { get; }

        public GetVendorSubscriptionsByIdQuery(Guid vendorId)
        {
            VendorId = vendorId;
        }
    }
}
