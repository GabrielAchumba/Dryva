using CustomerSubscription.API.Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CustomerSubscription.API.Application.Queries
{
    public class GetSubscribersQueryAsync : IRequest<IEnumerable<SubscriberDto>>
    {
    }
}
