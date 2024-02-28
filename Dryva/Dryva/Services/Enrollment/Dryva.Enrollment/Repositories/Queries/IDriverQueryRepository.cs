using Dryva.Enrollment.DTOs.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    /// <summary>
    /// Interface IDriverQueryRepository
    /// </summary>
    public interface IDriverQueryRepository
    {
        /// <summary>
        /// Gets the driver by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;SingleDetailDTO&gt;.</returns>
        Task<DriverDataDTO> GetDriverById(Guid id);
        /// <summary>
        /// Gets the drivers.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IEnumerable&lt;DetailsDTO&gt;&gt;.</returns>
        Task<IEnumerable<DriverDetailDTO>> GetDrivers(int pageIndex = 1, int pageSize = 100);

        Task<DriverDataDTO> GetDriverByPhoneNumber(string phoneNumber);
        Task<DriverDataDTO> GetDriverByPlateNumber(string plateNumber);
        Task<DriverRegistrationDTO> GetDriverRegistrationByPhoneNumber(string phoneNumber);
    }
}