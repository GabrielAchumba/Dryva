using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
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
    public class UpdateCustomerPersonalDataHandler : IRequestHandler<UpdateCustomerPersonalDataCommand, CustomerPersonalDataDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<UpdateCustomerPersonalDataHandler> _logger;
        private IMapper _mapper;

        public UpdateCustomerPersonalDataHandler(
            EnrollmentDbContext context,
            ILogger<UpdateCustomerPersonalDataHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CustomerPersonalDataDTO> Handle(UpdateCustomerPersonalDataCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateCustomerPersonalData handler");

            var customer = _context.Customers.SingleOrDefault(x => x.Id == request.Id);
            if (customer == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Customer, customer);
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerPersonalDataDTO>(customer);
        }
    }
}
