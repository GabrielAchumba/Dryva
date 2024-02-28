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
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDataDTO>
    {
        private readonly ICustomerQueryRepository _repository;
        private readonly ILogger<GetCustomerByIdHandler> _logger;
      
        public GetCustomerByIdHandler(ICustomerQueryRepository repository, ILogger<GetCustomerByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CustomerDataDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetCustomerById handler");
            return await _repository.GetCustomerById(request.CustomerId);
        }
    }
}
