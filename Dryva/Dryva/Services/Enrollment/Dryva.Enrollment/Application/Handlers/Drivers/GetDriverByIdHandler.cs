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
    public class GetDriverByIdHandler : IRequestHandler<GetDriverByIdQuery, DriverDataDTO>
    {
        private readonly IDriverQueryRepository _repository;
        private readonly ILogger<GetDriverByIdHandler> _logger;
      
        public GetDriverByIdHandler(IDriverQueryRepository repository, ILogger<GetDriverByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<DriverDataDTO> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDriverById handler");
            return await _repository.GetDriverById(request.Id);
        }
    }
}
