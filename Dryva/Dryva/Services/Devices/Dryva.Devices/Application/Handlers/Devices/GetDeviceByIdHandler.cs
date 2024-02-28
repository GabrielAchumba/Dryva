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
    public class GetDeviceByIdHandler : IRequestHandler<GetDeviceByIdQuery, DetailsDTO>
    {
        private readonly IDeviceQueryRepository _repository;
        private readonly ILogger<GetDeviceByIdHandler> _logger;
      
        public GetDeviceByIdHandler(IDeviceQueryRepository repository, ILogger<GetDeviceByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<DetailsDTO> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDevicById handler");
            return await _repository.GetDevice(request.Id);
        }
    }
}
