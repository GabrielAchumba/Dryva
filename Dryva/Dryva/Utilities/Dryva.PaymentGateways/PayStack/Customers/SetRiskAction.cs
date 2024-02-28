using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the CustomerSetRiskActionData class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.CustomerList.Datum" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.CustomerList.Datum" />
    public class CustomerSetRiskActionData : CustomerList.Datum
    {
        /// <summary>
        /// Gets or sets the risk action.
        /// </summary>
        /// <value>The risk action.</value>
        [JsonProperty("risk_action")]
        public string RiskAction { get; set; }
    }

    /// <summary>
    /// Represents the CustomerSetRiskActionRequest class.
    /// </summary>
    public class CustomerSetRiskActionRequest
    {
        /// <summary>
        /// Customer's ID, Code, or Email Address
        /// </summary>
        /// <value>The customer.</value>
        public string Customer { get; set; }

        /// <summary>
        /// One of the possible risk actions. 'allow' to whitelist. 'deny' to blacklist.
        /// </summary>
        /// <value>The risk action.</value>
        [JsonProperty("risk_action")]
        public string RiskAction { get; set; }
    }

    /// <summary>
    /// Represents the CustomerSetRiskActionResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class CustomerSetRiskActionResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomerSetRiskActionResponse"/> request was successful.
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
        public CustomerSetRiskActionData Data { get; set; }
    }
}