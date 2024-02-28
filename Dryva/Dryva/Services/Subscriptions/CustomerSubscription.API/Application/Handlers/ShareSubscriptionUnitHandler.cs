using AutoMapper;
using CustomerSubscription.API.Application.Commands;
using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerSubscription.API.Application.Handlers
{
    public class ShareSubscriptionUnitHandler : IRequestHandler<ShareSubscriptionUnitCommand, SubscriptionDto>
    {
        // yet to be implemented feature.

        public ShareSubscriptionUnitHandler(IMapper mapper, ISubscriptionCommandRepository commandRepository)
        {
        }

        public Task<SubscriptionDto> Handle(ShareSubscriptionUnitCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
