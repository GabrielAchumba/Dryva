using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.Driver
{
    public class DriverOwnerNOKDTO : NewDriverOwnerNOKDTO
    {
        public Guid Id { get; set; }
    }
    /// <summary>
    /// Represents the driver owner and next of kin DTO class.
    /// </summary>
    public class NewDriverOwnerNOKDTO 
    {
        /// <summary>
        /// Gets or sets a value indicating whether the driver is the vehicle owner.
        /// </summary>
        /// <value><c>true</c> if the driver is the owner; otherwise, <c>false</c>.</value>
        public bool IsOwner { get; set; }
        /// <summary>
        /// Gets or sets the owner surname.
        /// </summary>
        /// <value>The owner surname.</value>
        public string OwnerSurname { get; set; }
        /// <summary>
        /// Gets or sets the first name of the owner.
        /// </summary>
        /// <value>The first name of the owner.</value>
        public string OwnerFirstName { get; set; }
        /// <summary>
        /// Gets or sets the owner address.
        /// </summary>
        /// <value>The owner address.</value>
        public string OwnerAddress { get; set; }
        /// <summary>
        /// Gets or sets the owner email.
        /// </summary>
        /// <value>The owner email.</value>
        public string OwnerEmail { get; set; }
        /// <summary>
        /// Gets or sets the owner phone number.
        /// </summary>
        /// <value>The owner phone number.</value>
        public string OwnerPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the next of kin names.
        /// </summary>
        /// <value>The next of kin names.</value>
        public string NOKNames { get; set; }
        /// <summary>
        /// Gets or sets the next of kin address.
        /// </summary>
        /// <value>The next of kin address.</value>
        public string NOKAddress { get; set; }
        /// <summary>
        /// Gets or sets the next of kin phone number.
        /// </summary>
        /// <value>The next of kin phone number.</value>
        public string NOKPhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the next of kin relationship.
        /// </summary>
        /// <value>The next of kin relationship.</value>
        public string NOKRelationship { get; set; }
    }
}
