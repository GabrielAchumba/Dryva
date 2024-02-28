using Dryva.VendorSubscription.API.Application.Queries;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class GetVendorSubscriptionsByIdHandler : IRequestHandler<GetVendorSubscriptionsByIdQuery, IEnumerable<VendorSubscriptionDto>>
    {
        private readonly IVendorQueryRepository vendorQueryRepository;

        public GetVendorSubscriptionsByIdHandler(IVendorQueryRepository vendorQueryRepository)
        {
            this.vendorQueryRepository = vendorQueryRepository;
        }

        public async Task<IEnumerable<VendorSubscriptionDto>> Handle(GetVendorSubscriptionsByIdQuery request, CancellationToken cancellationToken)
        {
            return await vendorQueryRepository.GetVendorSubscriptionByIdAsync(request.VendorId);
        }
    }
}
