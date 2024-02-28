using AutoMapper;
using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Queries;
using CustomerSubscription.API.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Application.Handlers
{
    public class GetSubscriptionByIdHandler : IRequestHandler<GetSubscriptionByIdQuery, SubscriptionDto>
    {
        private readonly ISubscriptionQueryRepository _repository;
        private readonly ILogger<GetSubscriptionByIdHandler> _logger;

        public GetSubscriptionByIdHandler(ISubscriptionQueryRepository repository, IMapper mapper, ILogger<GetSubscriptionByIdHandler> logger) {
            _repository = repository;
            _logger = logger;
        }

        public async Task<SubscriptionDto> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetSubscriptionById handler");
            return await _repository.GetSubscriptionsBySubscriptionIdAsync(request.SubscriptionId);
        }
    }
}
