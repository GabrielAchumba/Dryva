using System;
using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents a ChargeTokenize class.
    /// </summary>
    public class ChargeTokenize
    {
        /// <summary>
        /// Represents a Customer class.
        /// </summary>
        public class Customer
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the customer code.
            /// </summary>
            /// <value>The customer code.</value>
            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

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
            /// Gets or sets the customer email.
            /// </summary>
            /// <value>The customer email.</value>
            [JsonProperty("email")]
            public string Email { get; set; }
        }

        /// <summary>
        /// Represents the Data class.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// Gets or sets the authorization code.
            /// </summary>
            /// <value>The authorization code.</value>
            [JsonProperty("authorization_code")]
            public string AuthorizationCode { get; set; }

            /// <summary>
            /// Gets or sets the type of the card.
            /// </summary>
            /// <value>The type of the card.</value>
            [JsonProperty("card_type")]
            public string CardType { get; set; }

            /// <summary>
            /// Gets or sets the last 4 card number.
            /// </summary>
            /// <value>The last 4 card number.</value>
            [JsonProperty("last4")]
            public string Last4 { get; set; }

            /// <summary>
            /// Gets or sets the card expiry month.
            /// </summary>
            /// <value>The card expiry month.</value>
            [JsonProperty("exp_month")]
            public string ExpMonth { get; set; }

            /// <summary>
            /// Gets or sets the card expiry year.
            /// </summary>
            /// <value>The card expiry year.</value>
            [JsonProperty("exp_year")]
            public string ExpYear { get; set; }

            /// <summary>
            /// Gets or sets the bin.
            /// </summary>
            /// <value>The bin.</value>
            [JsonProperty("bin")]
            public string Bin { get; set; }

            /// <summary>
            /// Gets or sets the bank.
            /// </summary>
            /// <value>The bank.</value>
            [JsonProperty("bank")]
            public string Bank { get; set; }

            /// <summary>
            /// Gets or sets the channel.
            /// </summary>
            /// <value>The channel.</value>
            [JsonProperty("channel")]
            public string Channel { get; set; }

            /// <summary>
            /// Gets or sets the signature.
            /// </summary>
            /// <value>The signature.</value>
            [JsonProperty("signature")]
            public string Signature { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="Data"/> is reusable.
            /// </summary>
            /// <value><c>true</c> if reusable; otherwise, <c>false</c>.</value>
            [JsonProperty("reusable")]
            public bool Reusable { get; set; }

            /// <summary>
            /// Gets or sets the country code.
            /// </summary>
            /// <value>The country code.</value>
            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            /// <summary>
            /// Gets or sets the customer.
            /// </summary>
            /// <value>The customer.</value>
            [JsonProperty("customer")]
            public Customer Customer { get; set; }
        }
    }

    /// <summary>
    /// Represents a ChargeTokenizeResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class ChargeTokenizeResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChargeTokenizeResponse"/> request is successful.
        /// </summary>
        /// <value><c>true</c> if request is successful; otherwise, <c>false</c>.</value>
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
        public ChargeTokenize.Data Data { get; set; }
    }
}