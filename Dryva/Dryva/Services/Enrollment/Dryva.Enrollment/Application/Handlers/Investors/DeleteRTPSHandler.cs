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
    public class DeleteRTPSHandler : IRequestHandler<DeleteRTPSCommand, int>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<DeleteRTPSHandler> _logger;

        public DeleteRTPSHandler(
            EnrollmentDbContext context,
            ILogger<DeleteRTPSHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteRTPSCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into DeleteRTPS handler");

            var model = _context.RTPs.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _context.RTPs.Remove(model);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
