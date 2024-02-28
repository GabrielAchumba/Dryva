using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Queries;
using CustomerSubscription.API.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Application.Handlers
{
    public class GetActiveSubscriptionByCardNumberHandler : IRequestHandler<GetActiveSubscriptionByCardSerialNumberQuery, SubscriptionDto>
    {
        private readonly ISubscriptionQueryRepository _queryRepository;
        private readonly ILogger<GetActiveSubscriptionByCardNumberHandler> _logger;

        public GetActiveSubscriptionByCardNumberHandler(ISubscriptionQueryRepository queryRepository, ILogger<GetActiveSubscriptionByCardNumberHandler> logger) {
            _queryRepository = queryRepository;
            _logger = logger;
        }

        public Task<SubscriptionDto> Handle(GetActiveSubscriptionByCardSerialNumberQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into Handler for GetActiveSubscriptionByCardNumber");
            return _queryRepository.GetActiveSubscriptionByCardSerialNumberAsync(request.CardSerialNumber);
        }
    }
}
