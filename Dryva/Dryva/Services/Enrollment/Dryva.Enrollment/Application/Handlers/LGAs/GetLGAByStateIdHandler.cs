using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Lga;
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
    public class GetLGAByStateIdHandler : IRequestHandler<GetLGAByStateIdQuery, IEnumerable<LGADTO>>
    {
        private readonly ILGAQueryRepository _repository;
        private readonly ILogger<GetLGAByStateIdHandler> _logger;
      
        public GetLGAByStateIdHandler(ILGAQueryRepository repository, ILogger<GetLGAByStateIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<LGADTO>> Handle(GetLGAByStateIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetLGAByStateId handler");
            return await _repository.GetByStateId(request.StateId);
        }
    }
}
