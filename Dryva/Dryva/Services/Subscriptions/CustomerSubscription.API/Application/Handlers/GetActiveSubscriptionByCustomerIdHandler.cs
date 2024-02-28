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
    public class GetActiveSubscriptionByCustomerIdHandler : IRequestHandler<GetActiveSubscriptionByCustomerIdQuery, IEnumerable<SubscriptionDto>>
    {
        private readonly ISubscriptionQueryRepository _queryRepository;
        private readonly ILogger<GetActiveSubscriptionByCustomerIdHandler> _logger;

        public GetActiveSubscriptionByCustomerIdHandler(ISubscriptionQueryRepository queryRepository, ILogger<GetActiveSubscriptionByCustomerIdHandler> logger) {
            this._queryRepository = queryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<SubscriptionDto>> Handle(GetActiveSubscriptionByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetActiveSubscriptionByCustomId Handler");
            return await _queryRepository.GetActiveSubscriptionByCustomerIdAsync(request.CustomerId);
        }
    }
}
