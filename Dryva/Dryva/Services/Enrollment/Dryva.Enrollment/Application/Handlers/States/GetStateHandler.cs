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
    public class GetStateHandler : IRequestHandler<GetStateQuery, IEnumerable<StateDTO>>
    {
        private readonly IStateQueryRepository _repository;
        private readonly ILogger<GetStateHandler> _logger;

        public GetStateHandler(IStateQueryRepository repository, ILogger<GetStateHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<StateDTO>> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetState handler");
            return await _repository.GetStates();
        }

    }
}
