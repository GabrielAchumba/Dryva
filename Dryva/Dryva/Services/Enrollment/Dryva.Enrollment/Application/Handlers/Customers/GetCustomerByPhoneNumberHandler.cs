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
    public class GetCustomerByPhoneNumberHandler : IRequestHandler<GetCustomerByPhoneNumberQuery, CustomerDataDTO>
    {
        private readonly ICustomerQueryRepository _repository;
        private readonly ILogger<GetCustomerByPhoneNumberHandler> _logger;
      
        public GetCustomerByPhoneNumberHandler(ICustomerQueryRepository repository, ILogger<GetCustomerByPhoneNumberHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CustomerDataDTO> Handle(GetCustomerByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetCustomerByPhoneNumber handler");
            return await _repository.GetCustomerByPhoneNumber(request.PhoneNumber);
        }
    }
}
