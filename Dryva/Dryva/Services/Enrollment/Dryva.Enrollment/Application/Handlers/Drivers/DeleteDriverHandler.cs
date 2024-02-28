using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Driver;
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
    public class DeleteDriverHandler : IRequestHandler<DeleteDriverCommand, int>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<DeleteDriverHandler> _logger;

        public DeleteDriverHandler(
            EnrollmentDbContext context,
            ILogger<DeleteDriverHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into DeleteDriver handler");

            var Driver = _context.Drivers.SingleOrDefault(x => x.Id == request.Id);
            if (Driver == null)
                throw new KeyNotFoundException("Id not found!");

            _context.Drivers.Remove(Driver);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
