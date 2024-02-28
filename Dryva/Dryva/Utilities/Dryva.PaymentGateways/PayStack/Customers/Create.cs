using System;
using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents a CustomerCreate class.
    /// </summary>
    public class CustomerCreate
    {
        /// <summary>
        /// Represents a Data class.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// Gets or sets the customer email.
            /// </summary>
            /// <value>The customer email.</value>
            [JsonProperty("email")]
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets the integration.
            /// </summary>
            /// <value>The integration.</value>
            [JsonProperty("integration")]
            public int Integration { get; set; }

            /// <summary>
            /// Gets or sets the domain.
            /// </summary>
            /// <value>The domain.</value>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// Gets or sets the customer code.
            /// </summary>
            /// <value>The customer code.</value>
            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the date created.
            /// </summary>
            /// <value>The date created.</value>
            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            /// <summary>
            /// Gets or sets the date updated.
            /// </summary>
            /// <value>The date updated.</value>
            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }
    }

    /// <summary>
    /// Represents the CustomerCreateRequest class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    public class CustomerCreateRequest : RequestMetadataExtender
    {
        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        public string Email { get; set; }

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
    /// Represents the CustomerCreateResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class CustomerCreateResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomerCreateResponse"/> request was successful.
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
        public CustomerCreate.Data Data { get; set; }
    }
}