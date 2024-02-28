using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;

namespace Dryva.VendorSubscription.API.Application.Queries
{
    public class GetCustomerSubscriptionsByDateRangeQuery : IRequest<IEnumerable<CustomerSubscriptionDto>>
    {
        public DateTimeOffset BeginDate { get; }

        public DateTimeOffset EndDate { get; }

        public GetCustomerSubscriptionsByDateRangeQuery(DateRangeParameter dateRangeParameter)
        {
            BeginDate = dateRangeParameter.BeginDate;
            EndDate = dateRangeParameter.EndDate;
        }

    }
}
