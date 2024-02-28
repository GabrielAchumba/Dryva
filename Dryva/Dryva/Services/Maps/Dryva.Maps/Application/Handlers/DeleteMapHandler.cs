using AutoMapper;
using Dryva.Maps.Application.Commands;
using Dryva.Maps.Repositories.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Maps.Application.Handlers
{
    public class DeleteMapHandler : IRequestHandler<DeleteMapCommand, int>
    {
        private readonly MapsDbContext _context;
        private readonly ILogger<DeleteMapHandler> _logger;

        public DeleteMapHandler(
            MapsDbContext context,
            ILogger<DeleteMapHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteMapCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into DeleteMap handler");

            var model = _context.MapAxes.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _context.MapAxes.Remove(model);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
