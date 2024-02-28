using Dryva.Enrollment.DTOs.State;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    /// <summary>
    /// Interface IStateQueryRepository
    /// </summary>
    public interface IStateQueryRepository
    {
        /// <summary>
        /// Gets the state by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;StateDTO&gt;.</returns>
        Task<StateDTO> GetStateById(Guid id);
        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;StateDTO&gt;&gt;.</returns>
        Task<IEnumerable<StateDTO>> GetStates(int pageIndex = 1, int pageSize = 100);
    }
}