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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<DeleteCustomerHandler> _logger;

        public DeleteCustomerHandler(
            EnrollmentDbContext context,
            ILogger<DeleteCustomerHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into DeleteCustomer handler");

            var customer = _context.Customers.SingleOrDefault(x => x.Id == request.Id);
            if (customer == null)
                throw new KeyNotFoundException("Id not found!");

            _context.Customers.Remove(customer);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
