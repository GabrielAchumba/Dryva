// ***********************************************************************
// Assembly         : Dryva.Enrollment
// Author           : INTEGRITY
// Created          : 12-23-2019
//
// Last Modified By : INTEGRITY
// Last Modified On : 12-23-2019
// ***********************************************************************
// <copyright file="IRTPSCommandRepository.cs" company="Dryva.Enrollment">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dryva.Enrollment.DTOs.Investor;
using System;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    /// <summary>
    /// Interface IRTPSCommandRepository
    /// </summary>
    public interface IRTPSCommandRepository
    {
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Delete(Guid id);
        /// <summary>
        /// Inserts the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Insert(InvestorDTO dtoModel);
        /// <summary>
        /// Updates the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Update(InvestorDTO dtoModel);
    }
}