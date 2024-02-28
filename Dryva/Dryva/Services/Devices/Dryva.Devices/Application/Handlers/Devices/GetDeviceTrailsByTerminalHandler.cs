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
    public class GetDeviceTrailsByTerminalHandler : IRequestHandler<GetDeviceTrailsByTerminalQuery, IEnumerable<DeviceTrailDTO>>
    {
        private readonly IDeviceQueryRepository _repository;
        private readonly ILogger<GetDeviceTrailsByTerminalHandler> _logger;
      
        public GetDeviceTrailsByTerminalHandler(IDeviceQueryRepository repository, ILogger<GetDeviceTrailsByTerminalHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<DeviceTrailDTO>> Handle(GetDeviceTrailsByTerminalQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDevicTrailsByTerminal handler");
            return await _repository.GetDeviceTrails(request.Terminal);
        }
    }
}
