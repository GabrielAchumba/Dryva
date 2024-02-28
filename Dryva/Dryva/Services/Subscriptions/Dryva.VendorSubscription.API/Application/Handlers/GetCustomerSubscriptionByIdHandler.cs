using AutoMapper;
using Dryva.VendorSubscription.API.Application.Queries;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.Persistence.CustomerRecharge;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class GetCustomerSubscriptionByIdHandler : IRequestHandler<GetSubscriptionByIdQuery, CustomerSubscriptionDto>
    {
        private readonly ICustomerRechargeQueryRepository queryRepository;

        public GetCustomerSubscriptionByIdHandler(ICustomerRechargeQueryRepository queryRepository)
        {
            this.queryRepository = queryRepository;
        }

        public async Task<CustomerSubscriptionDto> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            return await queryRepository.GetCustomerSubscriptionById(request.RechargeId);
        }
    }
}
