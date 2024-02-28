using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.DTOs.Driver
{
    /// <summary>
    /// Represents the driver vehicle DTO class.
    /// Implements the <see cref="Dryva.Enrollment.DTOs.BaseDTO" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.DTOs.BaseDTO" />
    public class VehicleDTO : BaseDTO
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
