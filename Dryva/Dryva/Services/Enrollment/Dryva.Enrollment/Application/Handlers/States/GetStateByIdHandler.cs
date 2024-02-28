using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.State;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Handlers
{
    public class GetStateByIdHandler : IRequestHandler<GetStateByIdQuery, StateDTO>
    {
        private readonly IStateQueryRepository _repository;
        private readonly ILogger<GetStateByIdHandler> _logger;
      
        public GetStateByIdHandler(IStateQueryRepository repository, ILogger<GetStateByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<StateDTO> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetStateById handler");
            return await _repository.GetStateById(request.Id);
        }
    }
}
