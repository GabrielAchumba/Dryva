using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Customer
{
    public class CustomerCSNDTO : NewCustomerCSNDTO
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        public Guid Id { get; set; }
    }
    /// <summary>
    /// Represents the NewCustomerCSNDTO class.
    /// Implements the <see cref="Dryva.Enrollment.DTOs.BaseDTO" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.DTOs.BaseDTO" />
    public class NewCustomerCSNDTO 
    { 
        /// <summary>
        /// Gets or sets the card serial number (CSN).
        /// </summary>
        /// <value>The CSN.</value>
        public long? Csn { get; set; }
    }
}
