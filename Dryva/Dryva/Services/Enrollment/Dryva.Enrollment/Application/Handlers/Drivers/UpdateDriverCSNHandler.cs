using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Driver;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
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
    public class UpdateDriverCSNHandler : IRequestHandler<UpdateDriverCSNCommand, DriverCSNDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<UpdateDriverCSNHandler> _logger;
        private IMapper _mapper;

        public UpdateDriverCSNHandler(
            EnrollmentDbContext context,
            ILogger<UpdateDriverCSNHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DriverCSNDTO> Handle(UpdateDriverCSNCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateDriverCSN handler");

            var Driver = _context.Drivers.SingleOrDefault(x => x.Id == request.Id);
            if (Driver == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Driver, Driver);
            _context.Drivers.Update(Driver);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DriverCSNDTO>(Driver);
        }
    }
}
