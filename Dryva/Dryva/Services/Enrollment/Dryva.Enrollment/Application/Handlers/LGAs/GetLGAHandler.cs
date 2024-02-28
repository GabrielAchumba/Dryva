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
    public class GetLGAHandler : IRequestHandler<GetLGAQuery, IEnumerable<LGADTO>>
    {
        private readonly ILGAQueryRepository _repository;
        private readonly ILogger<GetLGAHandler> _logger;

        public GetLGAHandler(ILGAQueryRepository repository, ILogger<GetLGAHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<LGADTO>> Handle(GetLGAQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetLGA handler");
            return await _repository.Get();
        }

    }
}
