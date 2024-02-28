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
    public class InsertDriverRegistrationDataHandler : IRequestHandler<InsertDriverRegistrationDataCommand, DriverRegistrationDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<InsertDriverRegistrationDataHandler> _logger;
        private IMapper _mapper;

        public InsertDriverRegistrationDataHandler(
            EnrollmentDbContext context,
            ILogger<InsertDriverRegistrationDataHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DriverRegistrationDTO> Handle(InsertDriverRegistrationDataCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertDriverRegistrationData handler");
            var model = this._mapper.Map<Driver>(request.Driver);

            await _context.Drivers.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<DriverRegistrationDTO>(model);
        }
    }
}
