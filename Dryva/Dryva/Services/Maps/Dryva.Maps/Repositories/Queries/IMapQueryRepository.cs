// ***********************************************************************
// Assembly         : Dryva.Maps
// Author           : INTEGRITY
// Created          : 12-20-2019
//
// Last Modified By : INTEGRITY
// Last Modified On : 12-21-2019
// ***********************************************************************
// <copyright file="IMapQueryRepository.cs" company="Dryva.Maps">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dryva.Maps.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Maps.Repositories.Queries
{
    /// <summary>
    /// Interface IMapQueryRepository
    /// </summary>
    public interface IMapQueryRepository
    {
        /// <summary>
        /// Gets the map axis by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;MapAxisDTO&gt;.</returns>
        Task<MapAxisDTO> GetMapAxisById(Guid id);
        /// <summary>
        /// Gets the map axises.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;MapAxisDTO&gt;&gt;.</returns>
        Task<IEnumerable<MapAxisDTO>> GetMapAxises(int pageIndex = 1, int pageSize = 100);

        /// <summary>
        /// Gets the closest map axis by location.
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns>Task&lt;MapAxisDTO&gt;.</returns>
        Task<MapAxisDTO> GetClosestMapAxisByLocation(float longitude, float latitude);
    }
}