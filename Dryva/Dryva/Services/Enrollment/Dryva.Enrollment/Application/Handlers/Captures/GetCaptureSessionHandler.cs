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
    public class GetCaptureSessionHandler : IRequestHandler<GetCaptureSessionQuery, IEnumerable<CaptureSessionDTO>>
    {
        private readonly ICaptureSessionQueryRepository _repository;
        private readonly ILogger<GetCaptureSessionHandler> _logger;

        public GetCaptureSessionHandler(ICaptureSessionQueryRepository repository, ILogger<GetCaptureSessionHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<CaptureSessionDTO>> Handle(GetCaptureSessionQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetCaptureSession handler");
            return await _repository.GetCaptureSessions();
        }

    }
}
