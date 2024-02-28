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
    public class GetDriverRegistrationByPhoneNumberHandler : IRequestHandler<GetDriverRegistrationByPhoneNumberQuery, DriverRegistrationDTO>
    {
        private readonly IDriverQueryRepository _repository;
        private readonly ILogger<GetDriverRegistrationByPhoneNumberHandler> _logger;
      
        public GetDriverRegistrationByPhoneNumberHandler(IDriverQueryRepository repository, ILogger<GetDriverRegistrationByPhoneNumberHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<DriverRegistrationDTO> Handle(GetDriverRegistrationByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetDriverRegistrationByPhoneNumber handler");
            return await _repository.GetDriverRegistrationByPhoneNumber(request.PhoneNumber);
        }
    }
}
