using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Driver
{
    public class DriverVehicleDTO : NewDriverVehicleDTO
    {
        public Guid Id { get; set; }
    }
    /// <summary>
    /// Represents the driver vehicle DTO class.
    /// </summary>
    public class NewDriverVehicleDTO 
    {
        /// <summary>
        /// Gets or sets the make and model.
        /// </summary>
        /// <value>The make and model.</value>
        public string MakeAndModel { get; set; }
        /// <summary>
        /// Gets or sets the chassis number.
        /// </summary>
        /// <value>The chassis number.</value>
        public string ChassisNumber { get; set; }
        /// <summary>
        /// Gets or sets the engine number.
        /// </summary>
        /// <value>The engine number.</value>
        public string EngineNumber { get; set; }
        /// <summary>
        /// Gets or sets the plate number.
        /// </summary>
        /// <value>The plate number.</value>
        public string PlateNumber { get; set; }
    }
}
