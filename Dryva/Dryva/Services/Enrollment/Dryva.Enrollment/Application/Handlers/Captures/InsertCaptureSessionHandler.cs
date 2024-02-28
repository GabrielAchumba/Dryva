using AutoMapper;
using Dryva.Enrollment.Application.Commands;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.CaptureSession;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Handlers
{
    public class InsertCaptureSessionHandler : IRequestHandler<InsertCaptureSessionCommand, CaptureSessionDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<InsertCaptureSessionHandler> _logger;
        private IMapper _mapper;

        public InsertCaptureSessionHandler(
            EnrollmentDbContext context,
            ILogger<InsertCaptureSessionHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CaptureSessionDTO> Handle(InsertCaptureSessionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertCaptureSession handler");
            var model = this._mapper.Map<CaptureSession>(request.Model);

            await _context.CaptureSessions.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<CaptureSessionDTO>(model);
        }
    }
}
