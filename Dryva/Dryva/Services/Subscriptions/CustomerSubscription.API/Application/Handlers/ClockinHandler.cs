using AutoMapper;
using CustomerSubscription.API.Application.Commands;
using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Application.Handlers
{
    public class ClockinHandler : IRequestHandler<ClockinCommand, SubscriptionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionCommandRepository _commandRepository;
        private readonly ILogger<ClockinHandler> _logger;

        public ClockinHandler(IMapper mapper, ISubscriptionCommandRepository commandRepository, ILogger<ClockinHandler> logger)
        {
            _mapper = mapper;
            _commandRepository = commandRepository;
            _logger = logger;
        }

        public async Task<SubscriptionDto> Handle(ClockinCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into Clock-in Handler");
            var subscription = await _commandRepository.Clockin(request.CardSerialNumber);
            return _mapper.Map<SubscriptionDto>(subscription);
        }
    }
}
