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
    public class GetRouteByIdHandler : IRequestHandler<GetRouteByIdQuery, RouteDTO>
    {
        private readonly IRouteQueryRepository _repository;
        private readonly ILogger<GetRouteByIdHandler> _logger;
      
        public GetRouteByIdHandler(IRouteQueryRepository repository, ILogger<GetRouteByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<RouteDTO> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetRouteById handler");
            return await _repository.GetRoute(request.Id);
        }
    }
}
