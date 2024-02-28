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
    public class InsertDeviceEntryLogHandler : IRequestHandler<InsertDeviceEntryLogCommand, EntryTransitLogDTO>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<InsertDeviceEntryLogHandler> _logger;
        private IMapper _mapper;

        public InsertDeviceEntryLogHandler(
            DevicesDbContext context,
            ILogger<InsertDeviceEntryLogHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EntryTransitLogDTO> Handle(InsertDeviceEntryLogCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertDeviceEntryLog handler");
            var model = this._mapper.Map<EntryTransitLog>(request.Model);

            await _context.EntryTransitLogs.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<EntryTransitLogDTO>(model);
        }
    }
}
