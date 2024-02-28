using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.DTOs.Customer
{
    public class ContactDataDTO : BaseDTO
    {
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
