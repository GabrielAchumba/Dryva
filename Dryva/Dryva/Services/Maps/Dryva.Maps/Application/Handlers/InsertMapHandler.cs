using AutoMapper;
using Dryva.Maps.Application.Commands;
using Dryva.Maps.DTOs;
using Dryva.Maps.Models;
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
    public class InsertMapHandler : IRequestHandler<InsertMapCommand, MapAxisDTO>
    {
        private readonly MapsDbContext _context;
        private readonly ILogger<InsertMapHandler> _logger;
        private IMapper _mapper;

        public InsertMapHandler(
            MapsDbContext context,
            ILogger<InsertMapHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<MapAxisDTO> Handle(InsertMapCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertMap handler");
            var model = this._mapper.Map<MapAxis>(request.Model);

            await _context.MapAxes.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<MapAxisDTO>(model);
        }
    }
}
