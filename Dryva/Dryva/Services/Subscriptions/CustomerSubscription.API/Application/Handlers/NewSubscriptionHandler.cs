using AutoMapper;
using CustomerSubscription.API.Application.Commands;
using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Models;
using CustomerSubscription.API.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Application.Handlers
{
    public class NewSubscriptionHandler : IRequestHandler<NewSubscriptionCommand, SubscriptionDto>
    {
        private readonly ISubscriptionCommandRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NewSubscriptionCommand> _logger;

        public NewSubscriptionHandler(ISubscriptionCommandRepository subscriptionRepository, IMapper mapper, ILogger<NewSubscriptionCommand> logger)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SubscriptionDto> Handle(NewSubscriptionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into NewSubscription handler");
            
            var subscription = _mapper.Map<Subscription>(request.NewSubscriptionDto);

            subscription.RechargeCode = GetRechargeCode();
            subscription.DepleteAmount = subscription.Amount;
            subscription.CreatedOn = subscription.ModifiedOn = DateTimeOffset.Now;

            _subscriptionRepository.AddSubscription(subscription);
            
            await _subscriptionRepository.SaveAsync();
            return _mapper.Map<SubscriptionDto>(subscription);
        }

        private static int GetRechargeCode()
        {
            var random = new Random();
            return random.Next();
        }
    }
}
