using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents a ChargeAuthorizationRequest class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    public class ChargeAuthorizationRequest : RequestMetadataExtender
    {
        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>The reference number.</value>
        public string Reference { get; set; }

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
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the sub account.
        /// </summary>
        /// <value>The sub account.</value>
        public string SubAccount { get; set; }

        /// <summary>
        /// Gets or sets the transaction charge.
        /// </summary>
        /// <value>The transaction charge.</value>
        [JsonProperty("transaction_charge")]
        public int TransactionCharge { get; set; }

        /// <summary>
        /// Gets or sets the bearer.
        /// </summary>
        /// <value>The bearer.</value>
        public string Bearer { get; set; }
    }

    /// <summary>
    /// Represents the ChargeAuthorizationResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class ChargeAuthorizationResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChargeAuthorizationResponse"/> is request was successful.
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
        public TransactionList.Datum Data { get; set; }
    }
}