using Dryva.VendorSubscription.API.Application.Queries;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.Persistence.CustomerRecharge;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class GetAllCustomerSubscriptionByVendorIdHandler : IRequestHandler<GetAllCustomerSubscriptionsByVendorIdQuery, IEnumerable<CustomerSubscriptionDto>>
    {
        private readonly ICustomerRechargeQueryRepository queryRepository;

        public GetAllCustomerSubscriptionByVendorIdHandler(ICustomerRechargeQueryRepository queryRepository) => this.queryRepository = queryRepository;

        public async Task<IEnumerable<CustomerSubscriptionDto>> Handle(GetAllCustomerSubscriptionsByVendorIdQuery request, CancellationToken cancellationToken) 
            => await queryRepository.GetCustomerSubscriptionByVendorIdAsync(request.VendorId);
    }
}
