using AutoMapper;
using Dryva.Maps.DTOs;
using Dryva.Maps.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Repositories.Commands
{
    /// <summary>
    /// Map command repository
    /// </summary>
    /// <seealso cref="Dryva.Maps.Repos.Commands.IMapCommandRepository" />
    /// 
    public class MapCommandRepository : IMapCommandRepository
    {
        private readonly MapsDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<MapCommandRepository> _logger;

        public MapCommandRepository(MapsDbContext dbContext, IMapper mapper, ILogger<MapCommandRepository> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Inserts the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>int</returns>
        public async Task<int> Insert(MapAxisDTO dtoModel)
        {
            _logger.LogInformation("Called into Insert Map Handler");
            var customer = mapper.Map<MapAxis>(dtoModel);
            dbContext.MapAxes.Add(customer);
            return await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>int</returns>
        public async Task<int> Update(MapAxisDTO dtoModel)
        {
            _logger.LogInformation("Called into Update Map Handler");
            var model = new MapAxis();
            model.Id = dtoModel.Id;

            dbContext.Attach(model);
            mapper.Map(dtoModel, model);
            return await dbContext.SaveChangesAsync();
        }
        
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>int</returns>
        public async Task<int> Delete(Guid id)
        {
            _logger.LogInformation("Called into Delete Map Handler");
            var model = new MapAxis { Id = id };

            dbContext.Attach(model);
            dbContext.Remove(model);
            return await dbContext.SaveChangesAsync();
        }
    }
}
