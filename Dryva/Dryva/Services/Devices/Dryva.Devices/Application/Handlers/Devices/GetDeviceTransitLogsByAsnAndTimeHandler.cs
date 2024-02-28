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
    public class GetDeviceTransitLogsByAsnAndTimeHandler : IRequestHandler<GetDeviceTransitLogsByCsnAndTimeQuery, IEnumerable<TransitLogDetailsDTO>>
    {
        private readonly IDeviceQueryRepository _repository;
        private readonly ILogger<GetDeviceTransitLogsByAsnAndTimeHandler> _logger;
      
        public GetDeviceTransitLogsByAsnAndTimeHandler(IDeviceQueryRepository repository, ILogger<GetDeviceTransitLogsByAsnAndTimeHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<TransitLogDetailsDTO>> Handle(GetDeviceTransitLogsByCsnAndTimeQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDevicTransitLogsByCSNAndTime handler");
            return await _repository.GetTransitLogsByCsnAndTime(request.CSN,request.From, request.To);
        }
    }
}
