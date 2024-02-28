using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents a CustomerList class.
    /// </summary>
    public class CustomerList
    {
        /// <summary>
        /// Represents a customer Photo class.
        /// </summary>
        public class Photo
        {
            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [JsonProperty("typeId")]
            public string TypeId { get; set; }

            /// <summary>
            /// Gets or sets the name of the type.
            /// </summary>
            /// <value>The name of the type.</value>
            [JsonProperty("typeName")]
            public string TypeName { get; set; }

            /// <summary>
            /// Gets or sets the URL.
            /// </summary>
            /// <value>The URL.</value>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this is the primary photo.
            /// </summary>
            /// <value><c>true</c> if this is the primary photo; otherwise, <c>false</c>.</value>
            [JsonProperty("isPrimary")]
            public bool IsPrimary { get; set; }
        }

        /// <summary>
        /// Represents a Metadata class.
        /// Implements the <see cref="System.Collections.Generic.Dictionary{System.String, System.Object}" />
        /// </summary>
        /// <seealso cref="System.Collections.Generic.Dictionary{System.String, System.Object}" />
        public class Metadata : Dictionary<string, object>
        {
            /// <summary>
            /// Gets or sets the customer photos.
            /// </summary>
            /// <value>The photos.</value>
            [JsonProperty("photos")]
            public IList<Photo> Photos { get; set; }
        }

        /// <summary>
        /// Represents a customer Datum class.
        /// </summary>
        public class Datum
        {
            /// <summary>
            /// Gets or sets the integration.
            /// </summary>
            /// <value>The integration.</value>
            [JsonProperty("integration")]
            public int Integration { get; set; }

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
            /// Gets or sets the email address.
            /// </summary>
            /// <value>The email address.</value>
            [JsonProperty("email")]
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets the phone number.
            /// </summary>
            /// <value>The phone number.</value>
            [JsonProperty("phone")]
            public string Phone { get; set; }

            /// <summary>
            /// Gets or sets the metadata.
            /// </summary>
            /// <value>The metadata.</value>
            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

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

        /// <summary>
        /// Represents a Meta class.
        /// </summary>
        public class Meta
        {
            /// <summary>
            /// Gets or sets the total.
            /// </summary>
            /// <value>The total.</value>
            [JsonProperty("total")]
            public int Total { get; set; }

            /// <summary>
            /// Gets or sets the skipped records.
            /// </summary>
            /// <value>The skipped records.</value>
            [JsonProperty("skipped")]
            public int Skipped { get; set; }

            /// <summary>
            /// Gets or sets the number of records per page.
            /// </summary>
            /// <value>The number of records per page.</value>
            [JsonProperty("perPage")]
            public int PerPage { get; set; }

            /// <summary>
            /// Gets or sets the page number.
            /// </summary>
            /// <value>The page number.</value>
            [JsonProperty("page")]
            public int Page { get; set; }

            /// <summary>
            /// Gets or sets the page count.
            /// </summary>
            /// <value>The page count.</value>
            [JsonProperty("pageCount")]
            public int PageCount { get; set; }
        }
    }

    /// <summary>
    /// Represents the CustomerListRequest class.
    /// </summary>
    public class CustomerListRequest
    {
        /// <summary>
        /// Gets or sets the number of records per page.
        /// </summary>
        /// <value>The number of records per page.</value>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int Page { get; set; }
    }

    /// <summary>
    /// Represents the CustomerListResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class CustomerListResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomerListResponse"/> request was successful.
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
        public IList<CustomerList.Datum> Data { get; set; }

        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        [JsonProperty("meta")]
        public CustomerList.Meta Meta { get; set; }
    }
}