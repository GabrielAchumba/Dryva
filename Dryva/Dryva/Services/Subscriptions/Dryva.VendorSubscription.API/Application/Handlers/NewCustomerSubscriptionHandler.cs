using AutoMapper;
using Dryva.VendorSubscription.API.Application.Commands;
using Dryva.VendorSubscription.API.Application.Models;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.Persistence.CustomerRecharge;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class NewCustomerSubscriptionHandler : IRequestHandler<NewCustomerSubscriptionCommand, CustomerSubscriptionDto>
    {
        private readonly ICustomerRechargeCommandRepository commandRepository;
        private readonly IMapper mapper;

        public NewCustomerSubscriptionHandler(ICustomerRechargeCommandRepository commandRepository, IMapper mapper)
        {
            this.commandRepository = commandRepository;
            this.mapper = mapper;
        }

        public async Task<CustomerSubscriptionDto> Handle(NewCustomerSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var customerRecharge = mapper.Map<CustomerSubscription>(request.CustomerRechargeDto);
            await commandRepository.AddSubscriptionAsync(customerRecharge);
            return mapper.Map<CustomerSubscriptionDto>(customerRecharge);
        }
    }
}
