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
    public class InsertRouteHandler : IRequestHandler<InsertRouteCommand, RouteDTO>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<InsertRouteHandler> _logger;
        private IMapper _mapper;

        public InsertRouteHandler(
            DevicesDbContext context,
            ILogger<InsertRouteHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<RouteDTO> Handle(InsertRouteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertRoute handler");
            var model = this._mapper.Map<Route>(request.Model);

            await _context.Routes.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<RouteDTO>(model);
        }
    }
}
