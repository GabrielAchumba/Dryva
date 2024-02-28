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
    public class GetDriverByPhoneNumberHandler : IRequestHandler<GetDriverByPhoneNumberQuery, DriverDataDTO>
    {
        private readonly IDriverQueryRepository _repository;
        private readonly ILogger<GetDriverByPhoneNumberHandler> _logger;
      
        public GetDriverByPhoneNumberHandler(IDriverQueryRepository repository, ILogger<GetDriverByPhoneNumberHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<DriverDataDTO> Handle(GetDriverByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDriverByPhoneNumber handler");
            return await _repository.GetDriverByPhoneNumber(request.PhoneNumber);
        }
    }
}
