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
    public class InsertDeviceExitLogHandler : IRequestHandler<InsertDeviceExitLogCommand, ExitTransitLogDTO>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<InsertDeviceExitLogHandler> _logger;
        private IMapper _mapper;

        public InsertDeviceExitLogHandler(
            DevicesDbContext context,
            ILogger<InsertDeviceExitLogHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ExitTransitLogDTO> Handle(InsertDeviceExitLogCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertDeviceExitLog handler");
            var model = this._mapper.Map<ExitTransitLog>(request.Model);

            await _context.ExitTransitLogs.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<ExitTransitLogDTO>(model);
        }
    }
}
