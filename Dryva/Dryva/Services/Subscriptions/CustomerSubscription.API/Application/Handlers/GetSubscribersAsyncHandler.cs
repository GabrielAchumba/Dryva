using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Queries;
using CustomerSubscription.API.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Application.Handlers
{
    public class GetSubscribersAsyncHandler : IRequestHandler<GetSubscribersQueryAsync, IEnumerable<SubscriberDto>>
    {
        private readonly ISubscriptionQueryRepository _queryRepository;
        private readonly ILogger<GetSubscribersAsyncHandler> _logger;

        public GetSubscribersAsyncHandler(ISubscriptionQueryRepository queryRepository, ILogger<GetSubscribersAsyncHandler> logger) {
            _queryRepository = queryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<SubscriberDto>> Handle(GetSubscribersQueryAsync request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetSubscribersAsync handler");
            return await _queryRepository.GetSubscribersByDateDescAsync();
        }
    }
}
