using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.Models;
using System;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    /// <summary>
    /// Represents the ICustomerCommandRepository interface.
    /// </summary>
    public interface ICustomerCommandRepository
    {
        /// <summary>
        /// Deletes the customer with the specified identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Delete(Guid id);
        /// <summary>
        /// Inserts the customer registration to repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="model">The customer.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Insert(Customer model);
        /// <summary>
        /// Updates the specified customer in repository.
        /// </summary>
        /// <param name="model">The customer.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Update(Customer model);

        /// <summary>
        /// Updates the specified customer bio data in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer bio data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Update(Guid id, NewCustomerBioDataDTO dtoCustomer);
        /// <summary>
        /// Updates the specified customer contact in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer contact DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Update(Guid id, NewCustomerContactDTO dtoCustomer);
        /// <summary>
        /// Updates the specified customer personal data in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer personal data DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Update(Guid id, NewCustomerPersonalDataDTO dtoCustomer);
        /// <summary>
        /// Updates the specified customer registration in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer registration DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<CustomerRegistrationDTO> Update(Guid id, NewCustomerRegistrationDTO dtoCustomer);
        /// <summary>
        /// Updates the specified customer CSN in repository.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dtoCustomer">The customer CSN DTO.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<CustomerCSNDTO> Update(Guid id, NewCustomerCSNDTO dtoCustomer);
    }
}