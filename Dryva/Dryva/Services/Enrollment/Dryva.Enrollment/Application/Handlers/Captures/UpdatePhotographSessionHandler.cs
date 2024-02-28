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
    public class UpdatePhotographSessionHandler : IRequestHandler<UpdatePhotographSessionCommand, UpdatePhotographSessionDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<UpdatePhotographSessionHandler> _logger;
        private IMapper _mapper;

        public UpdatePhotographSessionHandler(
            EnrollmentDbContext context,
            ILogger<UpdatePhotographSessionHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UpdatePhotographSessionDTO> Handle(UpdatePhotographSessionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdatePhotographSession handler");

            var model = _context.CaptureSessions.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Model, model);
            _context.CaptureSessions.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdatePhotographSessionDTO>(model);
        }
    }
}
