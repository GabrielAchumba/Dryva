using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Customer
{
    public class CustomerBioDataDTO : NewCustomerBioDataDTO
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Represents the new customer bio data DTO class.
    /// Implements the <see cref="Dryva.Enrollment.DTOs.BaseDTO" />
    /// Implements the <see cref="Dryva.Enrollment.DTOs.IBioDataDTO" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.DTOs.IBioDataDTO" />
    public class NewCustomerBioDataDTO : IBioDataDTO
    {
        /// <summary>
        /// Gets or sets the left thumb image.
        /// </summary>
        /// <value>The left thumb image.</value>
        public byte[] LeftThumbImage { get; set; }
        /// <summary>
        /// Gets or sets the left index image.
        /// </summary>
        /// <value>The left index image.</value>
        public byte[] LeftIndexImage { get; set; }
        /// <summary>
        /// Gets or sets the left thumb minutia.
        /// </summary>
        /// <value>The left thumb minutia.</value>
        public byte[] LeftThumbMinutia { get; set; }
        /// <summary>
        /// Gets or sets the left index minutia.
        /// </summary>
        /// <value>The left index minutia.</value>
        public byte[] LeftIndexMinutia { get; set; }

        /// <summary>
        /// Gets or sets the right thumb image.
        /// </summary>
        /// <value>The right thumb image.</value>
        public byte[] RightThumbImage { get; set; }
        /// <summary>
        /// Gets or sets the right index image.
        /// </summary>
        /// <value>The right index image.</value>
        public byte[] RightIndexImage { get; set; }
        /// <summary>
        /// Gets or sets the right thumb minutia.
        /// </summary>
        /// <value>The right thumb minutia.</value>
        public byte[] RightThumbMinutia { get; set; }
        /// <summary>
        /// Gets or sets the right index minutia.
        /// </summary>
        /// <value>The right index minutia.</value>
        public byte[] RightIndexMinutia { get; set; }

        /// <summary>
        /// Gets or sets the photograph.
        /// </summary>
        /// <value>The photograph.</value>
        public byte[] Photograph { get; set; }
        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>The signature.</value>
        public byte[] Signature { get; set; }
    }
}
