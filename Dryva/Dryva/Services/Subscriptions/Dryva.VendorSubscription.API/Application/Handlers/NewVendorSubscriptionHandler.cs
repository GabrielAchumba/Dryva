using AutoMapper;
using Dryva.VendorSubscription.API.Application.Commands;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class NewVendorSubscriptionHandler : IRequestHandler<NewVendorSubscriptionCommand, VendorSubscriptionDto>
    {
        private readonly IMapper mapper;
        private readonly IVendorCommandRepository vendorCommandRepository;
        public NewVendorSubscriptionHandler(IVendorCommandRepository vendorCommandRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.vendorCommandRepository = vendorCommandRepository;
        }

        public async Task<VendorSubscriptionDto> Handle(NewVendorSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var vendorSubscription = mapper.Map<Models.VendorSubscription>(request.NewVendorSubscriptionDto);
            var result = await vendorCommandRepository.AddSubscriptionAsync(vendorSubscription);
            return mapper.Map<VendorSubscriptionDto>(result);
        }
    }
}
