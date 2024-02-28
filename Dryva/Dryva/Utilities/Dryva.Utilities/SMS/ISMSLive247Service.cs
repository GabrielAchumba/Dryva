namespace Dryva.Utilities.SMS
{
    /// <summary>
    /// Represents the SMSLive247 interface.
    /// Implements the <see cref="Dryva.Utilities.SMS.ISMSService" />
    /// </summary>
    /// <seealso cref="Dryva.Utilities.SMS.ISMSService" />
    public interface ISMSLive247Service : ISMSService
    {
        /// <summary>
        /// Authenticates the service with the SMS gateway using the supplied credentials.
        /// </summary>
        /// <param name="email">The SMS account email.</param>
        /// <param name="name">The sub-account name.</param>
        /// <param name="password">The sub-account password.</param>
        /// <returns><c>true</c> if authenticated, <c>false</c> otherwise.</returns>
        bool Login(string email, string name, string password);
    }
}
