using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CusApp.DTOs.Customer
{
    /// <summary>
    /// Represents the customer registration DTO class.
    /// Implements the <see cref="Dryva.Enrollment.DTOs.BaseDTO" />
    /// Implements the <see cref="Dryva.Enrollment.DTOs.IRegistrationDTO" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.DTOs.BaseDTO" />
    /// <seealso cref="Dryva.Enrollment.DTOs.IRegistrationDTO" />
    public class RegistrationDTO : BaseDTO, IRegistrationDTO
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the other.
        /// </summary>
        /// <value>The name of the other.</value>
        public string OtherName { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the card serial number (CSN).
        /// </summary>
        /// <value>The CSN.</value>
        /// 
        public string PhoneNumber { get; set; }
        public long? Csn { get; set; }
    }
}
