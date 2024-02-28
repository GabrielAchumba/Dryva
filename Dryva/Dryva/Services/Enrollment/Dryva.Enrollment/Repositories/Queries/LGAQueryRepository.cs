using Dapper;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.DTOs.Lga;
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
    /// Class LGAQueryRepository.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Queries.ILGAQueryRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Queries.ILGAQueryRepository" />
    public class LGAQueryRepository : ILGAQueryRepository
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
        /// Initializes a new instance of the <see cref="LGAQueryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public LGAQueryRepository(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.connectionString = Startup.ConnectionString;
        }

        /// <summary>
        /// Gets the lg as.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        public async Task<IEnumerable<LGADTO>> Get(int pageIndex = 1, int pageSize = 100)
        {
            int startRow = (pageIndex - 1) * pageSize;
            if (startRow < 0)
                startRow = 0;

            int rowCount = pageSize;
            string paginationQuery = $" Order by [CreatedBy] OFFSET {startRow} ROWS FETCH NEXT {rowCount} ROWS ONLY";
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<Lga, LGADTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.StateName,
                    d.StateId
                });
                var models = await connection.QueryAsync<LGADTO>($"{builder.Query} {paginationQuery}");
                return models;
            }
        }

        /// <summary>
        /// Gets the lga by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;LGADTO&gt;.</returns>
        public async Task<LGADTO> GetById(Guid id)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<Lga, LGADTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.StateName,
                    d.StateId
                }).Where(d => d.Id == id);
                var model = await connection.QuerySingleOrDefaultAsync<LGADTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        /// <summary>
        /// Gets the lga by state identifier.
        /// </summary>
        /// <param name="stateId">The state identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        public async Task<IEnumerable<LGADTO>> GetByStateId(Guid stateId)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<Lga, LGADTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.StateName,
                    d.StateId
                }).Where(d => d.StateId == stateId);
                var model = await connection.QueryAsync<LGADTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }


        /// <summary>
        /// Gets the lga by state name.
        /// </summary>
        /// <param name="stateName">The state name.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        public async Task<IEnumerable<LGADTO>> GetByStateName(string stateName)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                var _stateName = stateName.ToLower();
                await connection.OpenAsync();
                var builder = dbContext.Select<Lga, LGADTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.StateName,
                    d.StateId
                }).Where(d => d.StateName.ToLower() == _stateName);
                var model = await connection.QueryAsync<LGADTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }
    }
}
