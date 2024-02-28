using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Driver
{

    public class DriverPersonalDataDTO : NewDriverPersonalDataDTO
    {
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Represents the driver personal data DTO class.
    /// Implements the <see cref="Dryva.Enrollment.DTOs.IPersonalDataDTO" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.DTOs.IPersonalDataDTO" />
    public class NewDriverPersonalDataDTO :  IPersonalDataDTO
    {
        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Gets or sets the blood group.
        /// </summary>
        /// <value>The blood group.</value>
        public string BloodGroup { get; set; }
        /// <summary>
        /// Gets or sets the genotype.
        /// </summary>
        /// <value>The genotype.</value>
        public string Genotype { get; set; }
        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        public string MaritalStatus { get; set; }
        /// <summary>
        /// Gets or sets the lga of origin.
        /// </summary>
        /// <value>The lga of origin.</value>
        public string LGAOfOrigin { get; set; }
        /// <summary>
        /// Gets or sets the state of origin.
        /// </summary>
        /// <value>The state of origin.</value>
        public string StateOfOrigin { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }
    }
}
