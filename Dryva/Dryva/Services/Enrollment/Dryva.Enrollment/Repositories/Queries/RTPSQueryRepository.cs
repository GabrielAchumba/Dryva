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
    /// Class RTPSQueryRepository.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Queries.IRTPSQueryRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Queries.IRTPSQueryRepository" />
    public class RTPSQueryRepository : IRTPSQueryRepository
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
        /// Initializes a new instance of the <see cref="RTPSQueryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public RTPSQueryRepository(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.connectionString = Startup.ConnectionString;
        }

        /// <summary>
        /// Gets the rt ps.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;InvestorDTO&gt;&gt;.</returns>
        public async Task<IEnumerable<InvestorDTO>> GetRTPs(int pageIndex = 1, int pageSize = 100)
        {
            int startRow = (pageIndex - 1) * pageSize;
            if (startRow < 0)
                startRow = 0;

            int rowCount = pageSize;
            string paginationQuery = $" Order by [CreatedBy] OFFSET {startRow} ROWS FETCH NEXT {rowCount} ROWS ONLY";
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<RTPS, InvestorDTO>(d => new
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
        /// Gets the RTPS by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;InvestorDTO&gt;.</returns>
        public async Task<InvestorDTO> GetRTPSById(Guid id)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<RTPS, InvestorDTO>(d => new
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
        /// Gets the RTPS by pin and phone number.
        /// </summary>
        /// <param name="pin">The pin.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Task&lt;InvestorDTO&gt;.</returns>
        public async Task<InvestorDTO> GetRTPSByPinAndPhoneNumber(int pin, string phoneNumber)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<RTPS, InvestorDTO>(d => new
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
                }).Where(d => d.PhoneNumber == phoneNumber);
                var model = await connection.QuerySingleOrDefaultAsync<InvestorDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }


    }
}
