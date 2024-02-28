using AutoMapper;
using Dryva.Devices.Application.Queries;
using Dryva.Devices.DTOs;
using Dryva.Devices.Repositories.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Handlers
{
    public class GetDeviceTransitLogsByCSNHandler : IRequestHandler<GetDeviceTransitLogsByCSNQuery, IEnumerable<TransitLogDetailsDTO>>
    {
        private readonly IDeviceQueryRepository _repository;
        private readonly ILogger<GetDeviceTransitLogsByCSNHandler> _logger;
      
        public GetDeviceTransitLogsByCSNHandler(IDeviceQueryRepository repository, ILogger<GetDeviceTransitLogsByCSNHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<TransitLogDetailsDTO>> Handle(GetDeviceTransitLogsByCSNQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDevicTransitLogsByCSN handler");
            return await _repository.GetTransitLogsByCsn(request.CSN);
        }
    }
}
