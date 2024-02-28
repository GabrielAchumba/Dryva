using CustomerSubscription.API.Application.Dtos;
using MediatR;

namespace CustomerSubscription.API.Application.Commands
{
    public class ClockinCommand : IRequest<SubscriptionDto>
    {

        public long CardSerialNumber { get; set; }

        public ClockinCommand(long cardSerialNumber)
        {
            CardSerialNumber = cardSerialNumber;
        }
    }
}
