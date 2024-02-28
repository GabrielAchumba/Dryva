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
    public class DeleteDeviceHandler : IRequestHandler<DeleteDeviceCommand, int>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<DeleteDeviceHandler> _logger;

        public DeleteDeviceHandler(
            DevicesDbContext context,
            ILogger<DeleteDeviceHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into DeleteDevice handler");

            var model = _context.Devices.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _context.Devices.Remove(model);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
