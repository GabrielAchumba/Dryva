using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Driver;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateDriverRegistrationDataHandler : IRequestHandler<UpdateDriverRegistrationDataCommand, DriverRegistrationDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<UpdateDriverRegistrationDataHandler> _logger;
        private IMapper _mapper;

        public UpdateDriverRegistrationDataHandler(
            EnrollmentDbContext context,
            ILogger<UpdateDriverRegistrationDataHandler> logger,
             IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DriverRegistrationDTO> Handle(UpdateDriverRegistrationDataCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateDriverRegistrationData handler");

            var Driver = _context.Drivers.SingleOrDefault(x => x.Id == request.Id);
            if (Driver == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Driver, Driver);
            _context.Drivers.Update(Driver);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DriverRegistrationDTO>(Driver);
        }
    }
}
