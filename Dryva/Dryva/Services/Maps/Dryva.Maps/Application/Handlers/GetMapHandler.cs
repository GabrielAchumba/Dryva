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
    public class GetMapHandler : IRequestHandler<GetMapQuery, IEnumerable<MapAxisDTO>>
    {
        private readonly IMapQueryRepository _repository;
        private readonly ILogger<GetMapHandler> _logger;

        public GetMapHandler(IMapQueryRepository repository, ILogger<GetMapHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<MapAxisDTO>> Handle(GetMapQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetMap handler");
            return await _repository.GetMapAxises(request.PageIndex,request.PageSize);
        }
    }
}
