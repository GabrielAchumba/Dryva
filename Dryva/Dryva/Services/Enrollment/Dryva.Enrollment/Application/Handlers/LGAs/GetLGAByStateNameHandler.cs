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
    public class GetLGAByStateNameHandler : IRequestHandler<GetLGAByStateNameQuery, IEnumerable<LGADTO>>
    {
        private readonly ILGAQueryRepository _repository;
        private readonly ILogger<GetLGAByStateNameHandler> _logger;
      
        public GetLGAByStateNameHandler(ILGAQueryRepository repository, ILogger<GetLGAByStateNameHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<LGADTO>> Handle(GetLGAByStateNameQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetLGAByStateName handler");
            return await _repository.GetByStateName(request.StateName);
        }
    }
}
