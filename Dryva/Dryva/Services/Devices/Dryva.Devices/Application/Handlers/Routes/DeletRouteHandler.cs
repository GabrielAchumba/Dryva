using AutoMapper;
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
    public class DeletRouteHandler : IRequestHandler<DeleteRouteCommand, int>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<DeletRouteHandler> _logger;

        public DeletRouteHandler(
            DevicesDbContext context,
            ILogger<DeletRouteHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into DeleteRoute handler");

            var model = _context.Routes.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _context.Routes.Remove(model);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
