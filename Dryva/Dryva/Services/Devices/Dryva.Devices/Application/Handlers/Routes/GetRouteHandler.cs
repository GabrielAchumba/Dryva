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

namespace Dryva.Enrollment.Application.Handlers
{
    public class GetRouteHandler : IRequestHandler<GetRouteQuery, IEnumerable<RouteDTO>>
    {
        private readonly IRouteQueryRepository _repository;
        private readonly ILogger<GetRouteHandler> _logger;

        public GetRouteHandler(IRouteQueryRepository repository, ILogger<GetRouteHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<RouteDTO>> Handle(GetRouteQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetRoutes handler");
            return await _repository.GetRoutes();
        }
    }
}
