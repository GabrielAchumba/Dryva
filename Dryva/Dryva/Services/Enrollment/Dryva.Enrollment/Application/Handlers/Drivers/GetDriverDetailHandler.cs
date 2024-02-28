using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Driver;
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
    public class GetDriverDetailHandler : IRequestHandler<GetDriverDetailQuery, IEnumerable<DriverDetailDTO>>
    {
        private readonly IDriverQueryRepository _repository;
        private readonly ILogger<GetDriverDetailHandler> _logger;
      
        public GetDriverDetailHandler(IDriverQueryRepository repository, ILogger<GetDriverDetailHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<DriverDetailDTO>> Handle(GetDriverDetailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDriverDetail handler");
            return await _repository.GetDrivers();
        }
    }
}
