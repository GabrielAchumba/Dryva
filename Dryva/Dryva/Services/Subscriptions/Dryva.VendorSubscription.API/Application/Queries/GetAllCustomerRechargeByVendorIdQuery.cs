using Dryva.VendorSubscription.API.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Dryva.VendorSubscription.API.Application.Queries
{
    public class GetAllCustomerSubscriptionsByVendorIdQuery : IRequest<IEnumerable<CustomerSubscriptionDto>>
    {
        public GetAllCustomerSubscriptionsByVendorIdQuery(Guid vendorId)
        {
            VendorId = vendorId;
        }
        public Guid VendorId { get; }
    }
}
