using AutoMapper;
using Dryva.Enrollment.DTOs.Driver;
using Dryva.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    /// <summary>
    /// Class DriverCommandRepository.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Commands.IDriverCommandRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Commands.IDriverCommandRepository" />
    public class DriverCommandRepository : IDriverCommandRepository
    {
        private readonly EnrollmentDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverCommandRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="mapper">The object auto mapper.</param>
        public DriverCommandRepository(EnrollmentDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Inserts the driver registration to repository.
        /// </summary>
        /// <param name="dtoModel">The driver registration DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Insert(DriverRegistrationDTO dtoModel)
        {
            var driver = mapper.Map<Driver>(dtoModel);
            context.Drivers.Add(driver);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified driver registration in repository.
        /// </summary>
        /// <param name="dtoModel">The driver registration DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(DriverRegistrationDTO dtoModel)
        {
            var driver = new Driver();
            driver.Id = dtoModel.Id;

            context.Attach(driver);
            mapper.Map(dtoModel, driver);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified driver personal data in repository.
        /// </summary>
        /// <param name="dtoModel">The driver personal data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(DriverPersonalDataDTO dtoModel)
        {
            var driver = new Driver();
            driver.Id = dtoModel.Id;

            context.Attach(driver);
            mapper.Map(dtoModel, driver);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified driver contact in repository.
        /// </summary>
        /// <param name="dtoModel">The driver contact DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(DriverContactDTO dtoModel)
        {
            var driver = new Driver();
            driver.Id = dtoModel.Id;

            context.Attach(driver);
            mapper.Map(dtoModel, driver);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified driver bio data in repository.
        /// </summary>
        /// <param name="dtoModel">The driver bio data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(DriverBioDataDTO dtoModel)
        {
            var driver = new Driver();
            driver.Id = dtoModel.Id;

            context.Attach(driver);
            mapper.Map(dtoModel, driver);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(DriverOwnerNOKDTO dtoModel)
        {
            var driver = new Driver();
            driver.Id = dtoModel.Id;

            context.Attach(driver);
            mapper.Map(dtoModel, driver);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(DriverVehicleDTO dtoModel)
        {
            var driver = new Driver();
            driver.Id = dtoModel.Id;

            context.Attach(driver);
            mapper.Map(dtoModel, driver);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the driver with the specified identifier.
        /// </summary>
        /// <param name="id">The driver identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Delete(Guid id)
        {
            var driver = new Driver { Id = id };

            context.Attach(driver);
            context.Remove(driver);
            return await context.SaveChangesAsync();
        }
    }
}
