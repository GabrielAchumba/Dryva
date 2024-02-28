using AutoMapper;
using Dryva.Devices.Application.Commands;
using Dryva.Devices.DTOs;
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
    public class UpdateRouteHandler : IRequestHandler<UpdateRouteCommand, RouteDTO>
    {
        private readonly DevicesDbContext _context;
        private readonly ILogger<UpdateRouteHandler> _logger;
        private IMapper _mapper;

        public UpdateRouteHandler(
            DevicesDbContext context,
            ILogger<UpdateRouteHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<RouteDTO> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateRoute handler");

            var model = _context.Routes.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Model, model);
            _context.Routes.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RouteDTO>(model);
        }
    }
}
