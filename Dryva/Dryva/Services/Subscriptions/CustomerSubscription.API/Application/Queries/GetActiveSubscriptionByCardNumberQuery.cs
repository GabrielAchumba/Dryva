using CustomerSubscription.API.Application.Dtos;
using MediatR;

namespace CustomerSubscription.API.Application.Queries
{
    public class GetActiveSubscriptionByCardSerialNumberQuery : IRequest<SubscriptionDto>
    {
        public long CardSerialNumber { get; }
        public GetActiveSubscriptionByCardSerialNumberQuery(long cardSerialNumber)
        {
            CardSerialNumber = cardSerialNumber;
        }
    }
}
