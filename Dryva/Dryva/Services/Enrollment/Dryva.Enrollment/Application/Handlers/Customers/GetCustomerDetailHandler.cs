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
    public class GetCustomerDetailHandler : IRequestHandler<GetCustomerDetailQuery, IEnumerable<CustomerDetailDTO>>
    {
        private readonly ICustomerQueryRepository _repository;
        private readonly ILogger<GetCustomerDetailHandler> _logger;
      
        public GetCustomerDetailHandler(ICustomerQueryRepository repository, ILogger<GetCustomerDetailHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<CustomerDetailDTO>> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetCustomerDetail handler");
            return await _repository.GetCustomers();
        }
    }
}
