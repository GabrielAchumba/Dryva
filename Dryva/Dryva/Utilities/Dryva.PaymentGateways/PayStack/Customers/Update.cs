using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the CustomerUpdateRequest class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    public class CustomerUpdateRequest : RequestMetadataExtender
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string Phone { get; set; }
    }

    /// <summary>
    /// Represents the CustomerUpdateResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class CustomerUpdateResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomerUpdateResponse"/> is request was successful.
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
        public CustomerList.Datum Data { get; set; }
    }
}