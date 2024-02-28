using AutoMapper;
using Dryva.Devices.DTOs;
using Dryva.Devices.Application.Commands;
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
    public class UpdateDeviceHandler : IRequestHandler<UpdateDeviceCommand, DeviceDTO>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<UpdateDeviceHandler> _logger;
        private IMapper _mapper;

        public UpdateDeviceHandler(
            DevicesDbContext context,
            ILogger<UpdateDeviceHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DeviceDTO> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateDevice handler");

            var model = _context.Devices.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Model, model);
            _context.Devices.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DeviceDTO>(model);
        }
    }
}
