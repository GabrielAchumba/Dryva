using System;

namespace Dryva.Enrollment.DTOs
{
    /// <summary>
    /// Represents the personal data DTO interface.
    /// </summary>
    public interface IPersonalDataDTO
    {
        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        DateTime? BirthDate { get; set; }
        /// <summary>
        /// Gets or sets the blood group.
        /// </summary>
        /// <value>The blood group.</value>
        string BloodGroup { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        string Country { get; set; }
        /// <summary>
        /// Gets or sets the genotype.
        /// </summary>
        /// <value>The genotype.</value>
        string Genotype { get; set; }
        /// <summary>
        /// Gets or sets the lga of origin.
        /// </summary>
        /// <value>The lga of origin.</value>
        string LGAOfOrigin { get; set; }
        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        string MaritalStatus { get; set; }
        /// <summary>
        /// Gets or sets the state of origin.
        /// </summary>
        /// <value>The state of origin.</value>
        string StateOfOrigin { get; set; }
    }
}