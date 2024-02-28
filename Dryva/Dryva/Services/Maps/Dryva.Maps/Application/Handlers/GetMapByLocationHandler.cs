using AutoMapper;
using Dryva.Maps.Application.Queries;
using Dryva.Maps.DTOs;
using Dryva.Maps.Repositories.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Maps.Application.Handlers
{
    public class GetMapByLocationHandler : IRequestHandler<GetMapByLocationQuery, MapAxisDTO>
    {
        private readonly IMapQueryRepository _repository;
        private readonly ILogger<GetMapByLocationHandler> _logger;

        public GetMapByLocationHandler(IMapQueryRepository repository, ILogger<GetMapByLocationHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<MapAxisDTO> Handle(GetMapByLocationQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetMapByLocation handler");
            return await _repository.GetClosestMapAxisByLocation(request.Longitude, request.Latitude);
        }
    }
}
