using CustomerSubscription.API.Application.Dtos;
using MediatR;

namespace CustomerSubscription.API.Application.Commands
{
    public class NewSubscriptionCommand : IRequest<SubscriptionDto>
    {
        public NewSubscriptionDto NewSubscriptionDto { get; }

        public NewSubscriptionCommand(NewSubscriptionDto subscriptionDto)
        {
            NewSubscriptionDto = subscriptionDto;
        }
    }
}
