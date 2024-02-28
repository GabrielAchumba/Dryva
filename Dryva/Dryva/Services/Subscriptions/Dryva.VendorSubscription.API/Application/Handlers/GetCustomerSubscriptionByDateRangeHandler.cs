using AutoMapper;
using Dryva.VendorSubscription.API.Application.Queries;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.Persistence.CustomerRecharge;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class GetCustomerSubscriptionByDateRangeHandler : IRequestHandler<GetCustomerSubscriptionsByDateRangeQuery, IEnumerable<CustomerSubscriptionDto>>
    {
        private readonly ICustomerRechargeQueryRepository queryRepository;

        public GetCustomerSubscriptionByDateRangeHandler(ICustomerRechargeQueryRepository queryRepository)
        {
            this.queryRepository = queryRepository;
        }

        public async Task<IEnumerable<CustomerSubscriptionDto>> Handle(GetCustomerSubscriptionsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            return await queryRepository.GetCustomerSubscriptionWithinDatesAsync(request.BeginDate, request.EndDate);
        }
    }
}
