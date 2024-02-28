using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Handlers
{
    public class InsertCustomerRegistrationDataHandler : IRequestHandler<InsertCustomerRegistrationDataCommand, CustomerRegistrationDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<InsertCustomerRegistrationDataHandler> _logger;
        private IMapper _mapper;

        public InsertCustomerRegistrationDataHandler(
            EnrollmentDbContext context,
            ILogger<InsertCustomerRegistrationDataHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CustomerRegistrationDTO> Handle(InsertCustomerRegistrationDataCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertCustomerRegistrationData handler");
            var model = this._mapper.Map<Customer>(request.Customer);

            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<CustomerRegistrationDTO>(model);
        }
    }
}
