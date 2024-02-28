using AutoMapper;
using Dryva.Enrollment.DTOs;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    /// <summary>
    /// Class RTPSCommandRepository.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Commands.IRTPSCommandRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Commands.IRTPSCommandRepository" />
    public class RTPSCommandRepository : IRTPSCommandRepository
    {
        private readonly EnrollmentDbContext dbContext;
        private readonly IMapper mapper;
        public RTPSCommandRepository(EnrollmentDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        /// <summary>
        /// Inserts the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>int</returns>
        public async Task<int> Insert(InvestorDTO dtoModel)
        {
            var customer = mapper.Map<RTPS>(dtoModel);
            dbContext.RTPs.Add(customer);
            return await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>int</returns>
        public async Task<int> Update(InvestorDTO dtoModel)
        {
            var model = new RTPS();
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
            var model = new RTPS { Id = id };

            dbContext.Attach(model);
            dbContext.Remove(model);
            return await dbContext.SaveChangesAsync();
        }
    }
}
