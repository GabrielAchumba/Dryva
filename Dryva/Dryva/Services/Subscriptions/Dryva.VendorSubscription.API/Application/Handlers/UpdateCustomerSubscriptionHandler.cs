using AutoMapper;
using Dryva.VendorSubscription.API.Application.Commands;
using Dryva.VendorSubscription.API.Dtos;
using Dryva.VendorSubscription.API.Persistence.CustomerRecharge;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class UpdateCustomerSubscriptionHandler : IRequestHandler<UpdateCustomerSubscriptionCommand, CustomerSubscriptionDto>
    {
        private readonly IMapper mapper;
        private readonly ICustomerRechargeCommandRepository commandRepository;
        private readonly ICustomerRechargeQueryRepository queryRepository;
        
        public UpdateCustomerSubscriptionHandler(IMapper mapper, ICustomerRechargeCommandRepository commandRepository, ICustomerRechargeQueryRepository queryRepository)
        {
            this.commandRepository = commandRepository;
            this.queryRepository = queryRepository;
            this.mapper = mapper;
        }

        public async Task<CustomerSubscriptionDto> Handle(UpdateCustomerSubscriptionCommand request, CancellationToken cancellationToken)
        {
            // Review instances.
            var subscriptiondto = await queryRepository.GetCustomerSubscriptionById(request.SubscriptionId);
            var subscription = mapper.Map<Models.CustomerSubscription>(subscriptiondto);
            mapper.Map(request.CustomerSubscriptionUpdateDto, subscription, typeof(CustomerSubscriptionUpdateDto), typeof(Models.CustomerSubscription));

            await commandRepository.UpdateSubscription(subscription);
            return mapper.Map<CustomerSubscriptionDto>(subscription);
        }
    }
}
