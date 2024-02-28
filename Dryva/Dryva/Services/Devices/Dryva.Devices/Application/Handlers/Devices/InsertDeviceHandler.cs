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
    public class InsertDeviceHandler : IRequestHandler<InsertDeviceCommand, DeviceDTO>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<InsertDeviceHandler> _logger;
        private IMapper _mapper;

        public InsertDeviceHandler(
            DevicesDbContext context,
            ILogger<InsertDeviceHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DeviceDTO> Handle(InsertDeviceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertDevice handler");
            var model = this._mapper.Map<Device>(request.Model);
            model.CreatedOn = DateTime.Now;
            
            await _context.Devices.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<DeviceDTO>(model);
        }
    }
}
