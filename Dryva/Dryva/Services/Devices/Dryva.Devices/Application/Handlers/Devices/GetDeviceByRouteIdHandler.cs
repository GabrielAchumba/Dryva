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
    public class GetDeviceByRouteIdHandler : IRequestHandler<GetDeviceByRouteIdQuery, DetailsDTO>
    {
        private readonly IDeviceQueryRepository _repository;
        private readonly ILogger<GetDeviceByRouteIdHandler> _logger;
      
        public GetDeviceByRouteIdHandler(IDeviceQueryRepository repository, ILogger<GetDeviceByRouteIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<DetailsDTO> Handle(GetDeviceByRouteIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDevicByRouteId handler");
            return await _repository.GetDevice(request.RouteId);
        }
    }
}
