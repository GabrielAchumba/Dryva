using Dapper;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.Helpers;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Utitlties.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    /// <summary>
    /// Class ShareHolderQueryRepository.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Queries.IShareholderQueryRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Queries.IShareholderQueryRepository" />
    public class ShareholderQueryRepository : IShareholderQueryRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly EnrollmentDbContext dbContext;
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string connectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShareHolder" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ShareholderQueryRepository(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.connectionString = Startup.ConnectionString;
        }

        /// <summary>
        /// Gets the share holders.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;InvestorDTO&gt;&gt;.</returns>
        public async Task<IEnumerable<InvestorDTO>> GetShareHolders(int pageIndex = 1, int pageSize = 100)
        {
            int startRow = (pageIndex - 1) * pageSize;
            if (startRow < 0)
                startRow = 0;

            int rowCount = pageSize;
            string paginationQuery = $" Order by [CreatedBy] OFFSET {startRow} ROWS FETCH NEXT {rowCount} ROWS ONLY";
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<Shareholder, InvestorDTO>(d => new
                {
                    d.Id,
                    d.Csn,
                    d.FirstName,
                    d.Gender,
                    d.OtherName,
                    d.Percentage,
                    d.Surname,
                    d.Title,
                    d.PhoneNumber
                });
                var models = await connection.QueryAsync<InvestorDTO>($"{builder.Query} {paginationQuery}");
                return models;
            }
        }

        /// <summary>
        /// Gets the share holder by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;InvestorDTO&gt;.</returns>
        public async Task<InvestorDTO> GetShareHolderById(Guid id)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<Shareholder, InvestorDTO>(d => new
                {
                    d.Id,
                    d.Csn,
                    d.FirstName,
                    d.Gender,
                    d.OtherName,
                    d.Percentage,
                    d.Surname,
                    d.Title,
                    d.PhoneNumber
                }).Where(d => d.Id == id);
                var model = await connection.QuerySingleOrDefaultAsync<InvestorDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }


        /// <summary>
        /// Gets the share holder by pin and phone number.
        /// </summary>
        /// <param name="pin">The pin.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;InvestorDTO&gt;.</returns>
        public async Task<InvestorDTO> GetShareHolderByPinAndPhoneNumber(int pin, string phoneNumber)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<Shareholder, InvestorDTO>(d => new
                {
                    d.Id,
                    d.Csn,
                    d.FirstName,
                    d.Gender,
                    d.OtherName,
                    d.Percentage,
                    d.Surname,
                    d.Title,
                    d.PhoneNumber
                }).Where(d =>d.PhoneNumber == phoneNumber);
                var model = await connection.QuerySingleOrDefaultAsync<InvestorDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }


    }
}
