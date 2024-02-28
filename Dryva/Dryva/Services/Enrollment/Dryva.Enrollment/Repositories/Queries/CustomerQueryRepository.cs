using Dapper;
using Dryva.Enrollment.DTOs;
using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.Helpers;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Utitlties.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    /// <summary>
    /// Represents the customer query repository class.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Queries.ICustomerQueryRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Queries.ICustomerQueryRepository" />
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly string connectionString;
        private readonly EnrollmentDbContext context;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerQueryRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>

        public CustomerQueryRepository(EnrollmentDbContext context)
        {
            connectionString = Startup.ConnectionString;
            this.context = context;
        }

        public async Task<bool> ModelExist(Guid id)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();                
                var builder = context.Select<Customer, BaseDTO>(d => new
                {
                    d.Id
                }).Where(d => d.Id == id);
                var model = await connection.QuerySingleOrDefaultAsync<BaseDTO>(builder.Query, (object)builder.Parameters);

                return model != null;
            }
        }

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;CustomerDetailDTO&gt;&gt;.</returns>
        public async Task<IEnumerable<CustomerDetailDTO>> GetCustomers(int pageIndex = 1, int pageSize = 100)
        {
            int startRow = (pageIndex - 1) * pageSize;
            if (startRow < 0)
                startRow = 0;

            int rowCount = pageSize;
            string paginationQuery = $" Order by [CreatedBy] OFFSET {startRow} ROWS FETCH NEXT {rowCount} ROWS ONLY";


            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Customer, CustomerDetailDTO>(d => new
                {
                    d.Id,
                    d.Title,
                    d.Surname,
                    d.FirstName,
                    d.OtherName,
                    d.Address,
                    d.PhoneNumber,
                    d.Email,
                    d.BirthDate,
                    d.Csn,
                    d.Gender,
                    d.Photograph,
                    d.LGAOfOrigin,
                    d.StateOfOrigin
                });
                var model = await connection.QueryAsync<CustomerDetailDTO>($"{builder.Query} {paginationQuery}");
                return model;
            }
        }
              

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>Task&lt;CustomerDataDTO&gt;.</returns>
        public async Task<CustomerDataDTO> GetCustomerById(Guid id)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Customer, CustomerDataDTO>(d => new
                {
                    d.Id,
                    d.Address,
                    d.BirthDate,
                    d.BloodGroup,
                    d.Country,
                    d.Csn,
                    d.Email,
                    d.FirstName,
                    d.Gender,
                    d.Genotype,
                    d.LeftIndexImage,
                    d.LeftIndexMinutia,
                    d.LeftThumbImage,
                    d.LeftThumbMinutia,
                    d.LGAOfOrigin,
                    d.MaritalStatus,
                    d.OtherName,
                    d.PhoneNumber,
                    d.Photograph,
                    d.ResidentialCity,
                    d.ResidentialState,
                    d.RightIndexImage,
                    d.RightIndexMinutia,
                    d.RightThumbImage,
                    d.RightThumbMinutia,
                    d.Signature,
                    d.StateOfOrigin,
                    d.Surname,
                    d.Title
                }).Where(d => d.Id == id);
                var model = await connection.QuerySingleOrDefaultAsync<CustomerDataDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        /// <summary>
        /// Gets the customer by phone number.
        /// </summary>
        /// <param name="phoneNumber">The customer phone number.</param>
        /// <returns>Task&lt;CustomerDataDTO&gt;.</returns>
        public async Task<CustomerDataDTO> GetCustomerByPhoneNumber(string phoneNumber)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Customer, CustomerDataDTO>(d => new
                {
                    d.Id,
                    d.Address,
                    d.BirthDate,
                    d.BloodGroup,
                    d.Country,
                    d.Csn,
                    d.Email,
                    d.FirstName,
                    d.Gender,
                    d.Genotype,
                    d.LeftIndexImage,
                    d.LeftIndexMinutia,
                    d.LeftThumbImage,
                    d.LeftThumbMinutia,
                    d.LGAOfOrigin,
                    d.MaritalStatus,
                    d.OtherName,
                    d.PhoneNumber,
                    d.Photograph,
                    d.ResidentialCity,
                    d.ResidentialState,
                    d.RightIndexImage,
                    d.RightIndexMinutia,
                    d.RightThumbImage,
                    d.RightThumbMinutia,
                    d.Signature,
                    d.StateOfOrigin,
                    d.Surname,
                    d.Title
                }).Where(d => d.PhoneNumber == phoneNumber);
                var model = await connection.QuerySingleOrDefaultAsync<CustomerDataDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        /// <summary>
        /// Gets the customer registration by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;CustomerRegistrationDTO&gt;.</returns>
        public async Task<CustomerRegistrationDTO> GetCustomerRegistrationByPhoneNumber(string phoneNumber)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Customer, CustomerRegistrationDTO>(d => new
                {
                    d.Id,
                    d.Csn,
                    d.FirstName,
                    d.Gender,
                    d.OtherName,
                    d.PhoneNumber,
                    d.Surname,
                    d.Title
                }).Where(d => d.PhoneNumber == phoneNumber);
                var model = await connection.QuerySingleOrDefaultAsync<CustomerRegistrationDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }
   
    
    }
}
