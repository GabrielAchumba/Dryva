namespace Dryva.Enrollment.DTOs
{
    /// <summary>
    /// Represents the contact DTO interface.
    /// </summary>
    public interface IContactDTO
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        string Address { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the residential city.
        /// </summary>
        /// <value>The residential city.</value>
        string ResidentialCity { get; set; }
        /// <summary>
        /// Gets or sets the state of the residential.
        /// </summary>
        /// <value>The state of the residential.</value>
        string ResidentialState { get; set; }
    }
}