using Dryva.Enrollment.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    /// <summary>
    /// Represents the customer query repository interface.
    /// </summary>
    public interface ICustomerQueryRepository
    {
        Task<bool> ModelExist(Guid id);

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>Task&lt;SingleDetail&gt;.</returns>
        Task<CustomerDataDTO> GetCustomerById(Guid id);

        /// <summary>
        /// Gets the customer by phoneNumber.
        /// </summary>
        /// <param name="id">The customer phoneNumber.</param>
        /// <returns>Task&lt;SingleDetail&gt;.</returns>
        Task<CustomerDataDTO> GetCustomerByPhoneNumber(string phoneNumber);

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;DetailsDTO&gt;&gt;.</returns>
        Task<IEnumerable<CustomerDetailDTO>> GetCustomers(int pageIndex = 1, int pageSize = 100);

        /// <summary>
        /// Gets the customer registration by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;CustomerRegistrationDTO&gt;.</returns>
        Task<CustomerRegistrationDTO> GetCustomerRegistrationByPhoneNumber(string phoneNumber);


    }
}