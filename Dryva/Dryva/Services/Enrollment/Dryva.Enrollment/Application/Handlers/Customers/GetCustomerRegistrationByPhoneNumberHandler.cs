using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Handlers
{
    public class GetCustomerRegistrationByPhoneNumberHandler : IRequestHandler<GetCustomerRegistrationByPhoneNumberQuery, CustomerRegistrationDTO>
    {
        private readonly ICustomerQueryRepository _repository;
        private readonly ILogger<GetCustomerRegistrationByPhoneNumberHandler> _logger;
      
        public GetCustomerRegistrationByPhoneNumberHandler(ICustomerQueryRepository repository, ILogger<GetCustomerRegistrationByPhoneNumberHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CustomerRegistrationDTO> Handle(GetCustomerRegistrationByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetCustomerRegistrationByPhoneNumber handler");
            return await _repository.GetCustomerRegistrationByPhoneNumber(request.PhoneNumber);
        }
    }
}
