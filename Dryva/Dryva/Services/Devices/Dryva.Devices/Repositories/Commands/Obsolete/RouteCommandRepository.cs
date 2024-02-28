using AutoMapper;
using Dryva.Devices.DTOs;
using Dryva.Devices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Commands
{
    public class RouteCommandRepository : IRouteCommandRepository
    {
        private readonly DevicesDbContext context;
        private readonly IMapper mapper;

        public RouteCommandRepository(DevicesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Insert(RouteDTO routeDTO)
        {
            var model = mapper.Map<RouteDTO, Route>(routeDTO);

            context.Routes.Add(model);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(RouteDTO routeDTO)
        {
            var model = new Route();
            model.Id = routeDTO.Id;

            context.Attach(model);
            mapper.Map(routeDTO, model);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid id)
        {
            var model = new Route { Id = id };

            context.Attach(model);
            context.Routes.Remove(model);
            return await context.SaveChangesAsync();
        }
        
    }
}
