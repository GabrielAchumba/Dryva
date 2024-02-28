using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Queries;
using CustomerSubscription.API.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Application.Handlers
{
    public class GetSubscriptionsHandler : IRequestHandler<GetSubscriptionsQuery, IEnumerable<SubscriptionDto>>
    {
        private readonly ISubscriptionQueryRepository _queryRepository;
        private readonly ILogger<GetSubscriptionsHandler> _logger;
        
        public GetSubscriptionsHandler(ISubscriptionQueryRepository queryRepository, ILogger<GetSubscriptionsHandler> logger) {
            _queryRepository = queryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetSubscriptions handler");
            
            return request.CustomerId == Guid.Empty ?
                await _queryRepository.GetSubscriptionsByCardNumberAsync(request.CardSerialNumber) :
                await _queryRepository.GetSubscriptionsByCustomerIdAsync(request.CustomerId);
        }
    }
}
