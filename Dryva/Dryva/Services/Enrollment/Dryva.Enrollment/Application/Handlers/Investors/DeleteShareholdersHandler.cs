using AutoMapper;
using Dryva.Enrollment.Application.Commands;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Investor;
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
    public class DeleteShareholdersHandler : IRequestHandler<DeleteShareholdersCommand, int>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<DeleteShareholdersHandler> _logger;

        public DeleteShareholdersHandler(
            EnrollmentDbContext context,
            ILogger<DeleteShareholdersHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteShareholdersCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into DeleteShareholders handler");

            var model = _context.Shareholders.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _context.Shareholders.Remove(model);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
