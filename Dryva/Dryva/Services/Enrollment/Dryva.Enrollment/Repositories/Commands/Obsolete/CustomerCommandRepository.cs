using AutoMapper;
using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Queries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    /// <summary>
    /// Represents the customer command repository class.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Commands.ICustomerCommandRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Commands.ICustomerCommandRepository" />
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly EnrollmentDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="mapper">The object auto mapper.</param>
        /// 
        public CustomerCommandRepository(EnrollmentDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Inserts the customer to repository.
        /// </summary>
        /// <param name="model">The customer registration DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Insert(Customer model)
        {
            await context.Customers.AddAsync(model);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified customer in repository.
        /// </summary>
        /// <param name="model">The customer.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(Customer model)
        {
            context.Attach(model);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified customer registration in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer registration DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<CustomerRegistrationDTO> Update(Guid id, NewCustomerRegistrationDTO dtoCustomer)
        {
            var customer = context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                new KeyNotFoundException("Id not valid");

            mapper.Map(dtoCustomer, customer);
            context.Customers.Update(customer);
            await context.SaveChangesAsync();

            return mapper.Map<CustomerRegistrationDTO>(customer);
        }

        /// <summary>
        /// Updates the specified customer CSN in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer CSN DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<CustomerCSNDTO> Update(Guid id, NewCustomerCSNDTO dtoCustomer)
        {
            var customer = context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                new KeyNotFoundException("Id not valid");

            mapper.Map(dtoCustomer, customer);
            context.Customers.Update(customer);
            await context.SaveChangesAsync();

            return mapper.Map<CustomerCSNDTO>(customer);
        }

        /// <summary>
        /// Updates the specified customer personal data in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer personal data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(Guid id, NewCustomerPersonalDataDTO dtoCustomer)
        {
            var customer = new Customer();
            customer.Id = id;

            context.Attach(customer);
            mapper.Map(dtoCustomer, customer);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified customer contact in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer contact DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(Guid id, NewCustomerContactDTO dtoCustomer)
        {
            var customer = new Customer();
            customer.Id = id;

            context.Attach(customer);
            mapper.Map(dtoCustomer, customer);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified customer bio data in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer bio data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Update(Guid id, NewCustomerBioDataDTO dtoCustomer)
        {
            var customer = new Customer();
            customer.Id = id;

            context.Attach(customer);
            mapper.Map(dtoCustomer, customer);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the customer with the specified identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Delete(Guid id)
        {
            var customer = new Customer { Id = id };

            context.Attach(customer);
            context.Remove(customer);
            return await context.SaveChangesAsync();
        }
    }
}
