using Dapper;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.DTOs.State;
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
    /// Class StateQueryRepository.
    /// Implements the <see cref="Dryva.Enrollment.Repositories.Queries.IStateQueryRepository" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.Repositories.Queries.IStateQueryRepository" />
    public class StateQueryRepository : IStateQueryRepository
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
        /// Initializes a new instance of the <see cref="StateQueryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public StateQueryRepository(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.connectionString = Startup.ConnectionString;
        }

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;StateDTO&gt;&gt;.</returns>
        public async Task<IEnumerable<StateDTO>> GetStates(int pageIndex = 1, int pageSize = 100)
        {
            int startRow = (pageIndex - 1) * pageSize;
            if (startRow < 0)
                startRow = 0;

            int rowCount = pageSize;
            string paginationQuery = $" Order by [CreatedBy] OFFSET {startRow} ROWS FETCH NEXT {rowCount} ROWS ONLY";
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<State, StateDTO>(d => new
                {
                    d.Id,
                    d.Name
                });
                var models = await connection.QueryAsync<StateDTO>($"{builder.Query} {paginationQuery}");
                return models;
            }
        }

        /// <summary>
        /// Gets the state by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;StateDTO&gt;.</returns>
        public async Task<StateDTO> GetStateById(Guid id)
        {
            using (var connection = ConnectionUtil.GetConnection(connectionString))
            {
                await connection.OpenAsync();
                var builder = dbContext.Select<State, StateDTO>(d => new
                {
                    d.Id,
                    d.Name
                }).Where(d => d.Id == id);
                var model = await connection.QuerySingleOrDefaultAsync<StateDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

    }
}
