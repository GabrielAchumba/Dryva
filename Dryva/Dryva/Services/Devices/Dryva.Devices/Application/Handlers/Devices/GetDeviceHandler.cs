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
    public class GetDeviceHandler : IRequestHandler<GetDeviceQuery, IEnumerable<DetailsDTO>>
    {
        private readonly IDeviceQueryRepository _repository;
        private readonly ILogger<GetDeviceHandler> _logger;

        public GetDeviceHandler(IDeviceQueryRepository repository, ILogger<GetDeviceHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<DetailsDTO>> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDevices handler");
            return await _repository.GetDevices();
        }
    }
}
