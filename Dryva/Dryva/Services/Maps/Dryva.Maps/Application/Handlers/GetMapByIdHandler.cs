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
    public class GetMapByIdHandler : IRequestHandler<GetMapByIdQuery, MapAxisDTO>
    {
        private readonly IMapQueryRepository _repository;
        private readonly ILogger<GetMapByIdHandler> _logger;
      
        public GetMapByIdHandler(IMapQueryRepository repository, ILogger<GetMapByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<MapAxisDTO> Handle(GetMapByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetMapById handler");
            return await _repository.GetMapAxisById(request.Id);
        }
    }
}
