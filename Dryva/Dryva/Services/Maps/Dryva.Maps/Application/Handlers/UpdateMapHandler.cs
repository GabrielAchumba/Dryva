using AutoMapper;
using Dryva.Maps.Application.Commands;
using Dryva.Maps.DTOs;
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
    public class UpdateMapHandler : IRequestHandler<UpdateMapCommand, MapAxisDTO>
    {
        private readonly MapsDbContext _context;
        private readonly ILogger<UpdateMapHandler> _logger;
        private IMapper _mapper;

        public UpdateMapHandler(
            MapsDbContext context,
            ILogger<UpdateMapHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<MapAxisDTO> Handle(UpdateMapCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateMap handler");

            var model = _context.MapAxes.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Model, model);
            _context.MapAxes.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<MapAxisDTO>(model);
        }
    }
}
