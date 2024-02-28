﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Driver
{
    public class DriverContactDTO : NewDriverContactDTO
    {
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Represents the driver contact DTO class.
    /// Implements the <see cref="Dryva.Enrollment.DTOs.IContactDTO" />
    /// </summary>
    /// <seealso cref="Dryva.Enrollment.DTOs.IContactDTO" />
    public class NewDriverContactDTO : IContactDTO
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
