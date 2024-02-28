using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.CaptureSession;
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
    public class GetCaptureSessionByIdHandler : IRequestHandler<GetCaptureSessionByIdQuery, CaptureSessionDTO>
    {
        private readonly ICaptureSessionQueryRepository _repository;
        private readonly ILogger<GetCaptureSessionByIdHandler> _logger;
      
        public GetCaptureSessionByIdHandler(ICaptureSessionQueryRepository repository, ILogger<GetCaptureSessionByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CaptureSessionDTO> Handle(GetCaptureSessionByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetCaptureSessionById handler");
            return await _repository.GetCaptureSession(request.Id);
        }
    }
}
