using System.Threading;
using System.Threading.Tasks;
using CustomerSubscription.API.Application.Dtos;
using CustomerSubscription.API.Application.Queries;
using CustomerSubscription.API.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CustomerSubscription.API.Application.Handlers {
    public class GetTripsInfoByCustomerIdHandler : IRequestHandler<GetTripsInfoByCustomerId, SubscriberTripsDetailDto> {

        private readonly ISubscriptionQueryRepository _queryRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<GetTripsInfoByCustomerIdHandler> _logger;

        public GetTripsInfoByCustomerIdHandler(ISubscriptionQueryRepository queryRepository, IConfiguration configuration, ILogger<GetTripsInfoByCustomerIdHandler> logger) {
            _queryRepository = queryRepository;
            _configuration = configuration;
            _logger = logger;
        }


        public async Task<SubscriberTripsDetailDto> Handle(GetTripsInfoByCustomerId request, CancellationToken cancellationToken) {
            _logger.LogInformation("Called into GetTripsInfoByCardNumber");
            
            var chargePerTrip = _configuration.GetValue<double>("ChargePerTrip");
            var availableTrips = await _queryRepository.GetDepleteAmount(request.CustomerId);

            if (availableTrips == null) {
                _logger.LogError("Could not find subscriber with customer Id {cardNumber}", request.CustomerId);
                return null;
            }

            if (availableTrips.DepleteAmount > default(double)) {
                availableTrips.AvailableTrips =  (int)(availableTrips.DepleteAmount / chargePerTrip);
            }

            return availableTrips;
        }
    }
}