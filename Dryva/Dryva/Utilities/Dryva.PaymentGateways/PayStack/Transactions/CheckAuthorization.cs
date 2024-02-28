using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the CheckAuthorizationRequest class.
    /// </summary>
    public class CheckAuthorizationRequest
    {

        /// <summary>
        /// Gets or sets the authorization code.
        /// </summary>
        /// <value>The authorization code.</value>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the amount in kobo.
        /// </summary>
        /// <value>The amount in kobo.</value>
        [JsonProperty("amount")]
        public int AmountInKobo { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public string Email { get; set; }

    }

    /// <summary>
    /// Represents the CheckAuthorizationResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class CheckAuthorizationResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CheckAuthorizationResponse"/> request was successful.
        /// </summary>
        /// <value><c>true</c> if request was successful; otherwise, <c>false</c>.</value>
        [JsonProperty("status")]
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>The response message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("data")]
        public CheckAuthorizationData Data { get; set; }
    }

    /// <summary>
    /// Represents the CheckAuthorizationData class.
    /// </summary>
    public class CheckAuthorizationData
    {
        /// <summary>
        /// Gets or sets the amount in kobo.
        /// </summary>
        /// <value>The amount in kobo.</value>
        [JsonProperty("amount")]
        public string AmountInKobo { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }
    }
}