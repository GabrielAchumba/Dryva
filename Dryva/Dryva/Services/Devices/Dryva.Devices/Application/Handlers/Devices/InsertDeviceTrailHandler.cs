using AutoMapper;
using Dryva.Devices.Application.Commands;
using Dryva.Devices.DTOs;
using Dryva.Devices.Models;
using Dryva.Devices.Repositories.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Handlers
{
    public class InsertDeviceTrailHandler : IRequestHandler<InsertDeviceTrailCommand, DeviceTrailDTO>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<InsertDeviceTrailHandler> _logger;
        private IMapper _mapper;

        public InsertDeviceTrailHandler(
            DevicesDbContext context,
            ILogger<InsertDeviceTrailHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DeviceTrailDTO> Handle(InsertDeviceTrailCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertDeviceTrail handler");
            var trail = this._mapper.Map<DeviceTrail>(request.Model);

            var device = new Device { Id = request.Model.DeviceId ?? Guid.Empty };

            await _context.DeviceTrails.AddAsync(trail);
            _context.Attach(device);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<DeviceTrailDTO>(trail);
        }
    }
}
