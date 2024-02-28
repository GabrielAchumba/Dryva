using Dryva.Enrollment.DTOs.Lga;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    /// <summary>
    /// Interface ILGAQueryRepository
    /// </summary>
    public interface ILGAQueryRepository
    {
        /// <summary>
        /// Gets the lga by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;LGADTO&gt;.</returns>
        Task<LGADTO> GetById(Guid id);
        /// <summary>
        /// Gets the lga by state identifier.
        /// </summary>
        /// <param name="stateId">The state identifier.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        Task<IEnumerable<LGADTO>> GetByStateId(Guid stateId);

        /// <summary>
        /// Gets the name of the by state.
        /// </summary>
        /// <param name="stateName">Name of the state.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        Task<IEnumerable<LGADTO>> GetByStateName(string stateName);

        /// <summary>
        /// Gets the lg as.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;LGADTO&gt;&gt;.</returns>
        Task<IEnumerable<LGADTO>> Get(int pageIndex = 1, int pageSize = 100);
    }
}