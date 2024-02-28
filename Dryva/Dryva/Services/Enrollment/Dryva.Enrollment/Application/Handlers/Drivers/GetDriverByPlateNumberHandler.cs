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
    public class GetDriverByPlateNumberHandler : IRequestHandler<GetDriverByPlateNumberQuery, DriverDataDTO>
    {
        private readonly IDriverQueryRepository _repository;
        private readonly ILogger<GetDriverByPlateNumberHandler> _logger;
      
        public GetDriverByPlateNumberHandler(IDriverQueryRepository repository, ILogger<GetDriverByPlateNumberHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<DriverDataDTO> Handle(GetDriverByPlateNumberQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDriverByPlateNumber handler");
            return await _repository.GetDriverByPlateNumber(request.PlateNumber);
        }
    }
}
