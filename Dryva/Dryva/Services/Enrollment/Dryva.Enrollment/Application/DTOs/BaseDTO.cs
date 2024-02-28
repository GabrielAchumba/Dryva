using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs
{
    /// <summary>
    /// Represents the base class for all DTO classes.
    /// </summary>
    public class BaseDTO
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        public Guid Id { get; set; }
    }
}
