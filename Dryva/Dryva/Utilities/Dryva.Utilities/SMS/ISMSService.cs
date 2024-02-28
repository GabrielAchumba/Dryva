using System;

namespace Dryva.Utilities.SMS
{
    /// <summary>
    /// Represents an SMS service interface.
    /// </summary>
    public interface ISMSService
    {
        /// <summary>
        /// Gets a value indicating whether the service is authenticated.
        /// </summary>
        /// <value><c>true</c> if the service is authenticated; otherwise, <c>false</c>.</value>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Queries the balance of SMS units left.
        /// </summary>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        int? QueryBalance();
        /// <summary>
        /// Sends the SMS message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sender">The sender Id.</param>
        /// <param name="sendTo">The receiver's phone number.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        int? SendMessage(string message, string sender, string sendTo);
        /// <summary>
        /// Sends the SMS message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sender">The sender Id.</param>
        /// <param name="sendTo">The receiver's phone number.</param>
        /// <param name="messageType">The type of the message.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        int? SendMessage(string message, string sender, string sendTo, int messageType);
    }
}
