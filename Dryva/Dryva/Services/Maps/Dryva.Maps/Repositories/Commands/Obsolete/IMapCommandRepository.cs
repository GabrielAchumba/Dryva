// ***********************************************************************
// Assembly         : Dryva.Maps
// Author           : INTEGRITY
// Created          : 12-20-2019
//
// Last Modified By : INTEGRITY
// Last Modified On : 12-21-2019
// ***********************************************************************
// <copyright file="IMapCommandRepository.cs" company="Dryva.Maps">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dryva.Maps.DTOs;
using System;
using System.Threading.Tasks;

namespace Dryva.Maps.Repositories.Commands
{
    /// <summary>
    /// Interface IMapCommandRepository
    /// </summary>
    public interface IMapCommandRepository
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
        Task<int> Insert(MapAxisDTO dtoModel);
        /// <summary>
        /// Updates the specified dto model.
        /// </summary>
        /// <param name="dtoModel">The dto model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Update(MapAxisDTO dtoModel);
    }
}