using AutoMapper;
using Dryva.Enrollment.Application.Commands;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.CaptureSession;
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
    public class UpdateFingerprintsSessionHandler : IRequestHandler<UpdateFingerprintsSessionCommand, UpdateFingerprintsSessionDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<UpdateFingerprintsSessionHandler> _logger;
        private IMapper _mapper;

        public UpdateFingerprintsSessionHandler(
            EnrollmentDbContext context,
            ILogger<UpdateFingerprintsSessionHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UpdateFingerprintsSessionDTO> Handle(UpdateFingerprintsSessionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateFingerprintsSession handler");

            var model = _context.CaptureSessions.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Model, model);
            _context.CaptureSessions.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateFingerprintsSessionDTO>(model);
        }
    }
}
