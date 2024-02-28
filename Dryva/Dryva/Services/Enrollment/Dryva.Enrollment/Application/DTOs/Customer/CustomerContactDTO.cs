using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Customer
{
    public class CustomerContactDTO : NewCustomerContactDTO
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        public Guid Id { get; set; }
    }

        /// <summary>
        /// Represents the new customer contact DTO class.
        /// Implements the <see cref="Dryva.Enrollment.DTOs.BaseDTO" />
        /// Implements the <see cref="Dryva.Enrollment.DTOs.IContactDTO" />
        /// </summary>
        /// <seealso cref="Dryva.Enrollment.DTOs.BaseDTO" />
        /// <seealso cref="Dryva.Enrollment.DTOs.IContactDTO" />
        public class NewCustomerContactDTO :  IContactDTO
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the residential city.
        /// </summary>
        /// <value>The residential city.</value>
        public string ResidentialCity { get; set; }
        /// <summary>
        /// Gets or sets the state of the residential.
        /// </summary>
        /// <value>The state of the residential.</value>
        public string ResidentialState { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
    }
}
