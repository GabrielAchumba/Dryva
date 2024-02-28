using System;
using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents a Charge class.
    /// </summary>
    public class Charge
    {
        /// <summary>
        /// Represents the Authorization class.
        /// </summary>
        public class Authorization
        {
            /// <summary>
            /// Gets or sets the authorization code to charge (don't send if charging a bank account).
            /// </summary>
            /// <value>The authorization code.</value>
            [JsonProperty("authorization_code")]
            public string AuthorizationCode { get; set; }

            /// <summary>
            /// Gets or sets the bin.
            /// </summary>
            /// <value>The bin.</value>
            [JsonProperty("bin")]
            public string Bin { get; set; }

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
            /// Gets or sets the channel.
            /// </summary>
            /// <value>The channel.</value>
            [JsonProperty("channel")]
            public string Channel { get; set; }

            /// <summary>
            /// Gets or sets the type of the card.
            /// </summary>
            /// <value>The type of the card.</value>
            [JsonProperty("card_type")]
            public string CardType { get; set; }

            /// <summary>
            /// Gets or sets the bank.
            /// </summary>
            /// <value>The bank.</value>
            [JsonProperty("bank")]
            public string Bank { get; set; }

            /// <summary>
            /// Gets or sets the country code.
            /// </summary>
            /// <value>The country code.</value>
            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            /// <summary>
            /// Gets or sets the brand.
            /// </summary>
            /// <value>The brand.</value>
            [JsonProperty("brand")]
            public string Brand { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="Authorization" /> is reusable.
            /// </summary>
            /// <value><c>true</c> if reusable; otherwise, <c>false</c>.</value>
            [JsonProperty("reusable")]
            public bool Reusable { get; set; }

            /// <summary>
            /// Gets or sets the signature.
            /// </summary>
            /// <value>The signature.</value>
            [JsonProperty("signature")]
            public string Signature { get; set; }
        }

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
            /// Gets or sets the first name.
            /// </summary>
            /// <value>The first name.</value>
            [JsonProperty("first_name")]
            public object FirstName { get; set; }

            /// <summary>
            /// Gets or sets the last name.
            /// </summary>
            /// <value>The last name.</value>
            [JsonProperty("last_name")]
            public object LastName { get; set; }

            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            /// <value>The email.</value>
            [JsonProperty("email")]
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets the customer code.
            /// </summary>
            /// <value>The customer code.</value>
            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

            /// <summary>
            /// Gets or sets the phone number.
            /// </summary>
            /// <value>The phone number.</value>
            [JsonProperty("phone")]
            public object Phone { get; set; }

            /// <summary>
            /// Gets or sets the metadata.
            /// </summary>
            /// <value>The metadata.</value>
            [JsonProperty("metadata")]
            public object Metadata { get; set; }

            /// <summary>
            /// Gets or sets the risk action.
            /// </summary>
            /// <value>The risk action.</value>
            [JsonProperty("risk_action")]
            public string RiskAction { get; set; }
        }

        /// <summary>
        /// Represents a Charge Data class.
        /// </summary>
        public class Data
        {

            /// <summary>
            /// Gets or sets the amount in kobo.
            /// </summary>
            /// <value>The amount.</value>
            [JsonProperty("amount")]
            public int Amount { get; set; }

            /// <summary>
            /// Gets or sets the currency.
            /// </summary>
            /// <value>The currency.</value>
            [JsonProperty("currency")]
            public string Currency { get; set; }

            /// <summary>
            /// Gets or sets the transaction date.
            /// </summary>
            /// <value>The transaction date.</value>
            [JsonProperty("transaction_date")]
            public DateTime TransactionDate { get; set; }

            /// <summary>
            /// Gets or sets the status.
            /// </summary>
            /// <value>The status.</value>
            [JsonProperty("status")]
            public string Status { get; set; }

            /// <summary>
            /// Gets or sets the URL.
            /// </summary>
            /// <value>The URL.</value>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Gets or sets the reference.
            /// </summary>
            /// <value>The reference.</value>
            [JsonProperty("reference")]
            public string Reference { get; set; }

            /// <summary>
            /// Gets or sets the domain.
            /// </summary>
            /// <value>The domain.</value>
            [JsonProperty("domain")]
            public string Domain { get; set; }

            /// <summary>
            /// Gets or sets the metadata.
            /// </summary>
            /// <value>The metadata.</value>
            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            /// <summary>
            /// Gets or sets the gateway response.
            /// </summary>
            /// <value>The gateway response.</value>
            [JsonProperty("gateway_response")]
            public string GatewayResponse { get; set; }

            /// <summary>
            /// Gets or sets the message.
            /// </summary>
            /// <value>The message.</value>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Gets or sets the display text.
            /// </summary>
            /// <value>The display text.</value>
            [JsonProperty("display_text")]
            public string DisplayText { get; set; }

            /// <summary>
            /// Gets or sets the channel.
            /// </summary>
            /// <value>The channel.</value>
            [JsonProperty("channel")]
            public string Channel { get; set; }

            /// <summary>
            /// Gets or sets the ip address.
            /// </summary>
            /// <value>The ip address.</value>
            [JsonProperty("ip_address")]
            public string IpAddress { get; set; }

            /// <summary>
            /// Gets or sets the log.
            /// </summary>
            /// <value>The log.</value>
            [JsonProperty("log")]
            public object Log { get; set; }

            /// <summary>
            /// Gets or sets the fees.
            /// </summary>
            /// <value>The fees.</value>
            [JsonProperty("fees")]
            public int Fees { get; set; }

            /// <summary>
            /// Gets or sets the authorization.
            /// </summary>
            /// <value>The authorization.</value>
            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }

            /// <summary>
            /// Gets or sets the customer.
            /// </summary>
            /// <value>The customer.</value>
            [JsonProperty("customer")]
            public Customer Customer { get; set; }

            /// <summary>
            /// Gets or sets the plan.
            /// </summary>
            /// <value>The plan.</value>
            [JsonProperty("plan")]
            public dynamic Plan { get; set; }
        }
    }

    /// <summary>
    /// Represents a Bank class.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
    }

    /// <summary>
    /// Represents a ChargeRequest class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.RequestMetadataExtender" />
    public class ChargeRequest : RequestMetadataExtender
    {
        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>The reference number.</value>
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
    }

    /// <summary>
    /// Represents a BankChargeRequest class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.ChargeRequest" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.ChargeRequest" />
    public class BankChargeRequest : ChargeRequest
    {
        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the amount in kobo.
        /// </summary>
        /// <value>The amount in kobo.</value>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        /// <value>The bank.</value>
        [JsonProperty("bank")]
        public Bank Bank { get; set; }

        /// <summary>
        /// Gets or sets the customer birthday.
        /// </summary>
        /// <value>The customer birthday.</value>
        [JsonProperty("birthday")]
        public string Birthday { get; set; }
    }

    /// <summary>
    /// Represents a Card class.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the CVV.
        /// </summary>
        /// <value>The CVV.</value>
        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the expiry month.
        /// </summary>
        /// <value>The expiry month.</value>
        [JsonProperty("expiry_month")]
        public string ExpiryMonth { get; set; }

        /// <summary>
        /// Gets or sets the expiry year.
        /// </summary>
        /// <value>The expiry year.</value>
        [JsonProperty("expiry_year")]
        public string ExpiryYear { get; set; }
    }

    /// <summary>
    /// Represents a CardChargeRequest class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.ChargeRequest" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.ChargeRequest" />
    public class CardChargeRequest : ChargeRequest
    {
        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the amount in kobo.
        /// </summary>
        /// <value>The amount in kobo.</value>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the card.
        /// </summary>
        /// <value>The card.</value>
        [JsonProperty("card")]
        public Card Card { get; set; }

        /// <summary>
        /// Gets or sets the pin number.
        /// </summary>
        /// <value>The pin number.</value>
        [JsonProperty("pin")]
        public string Pin { get; set; }
    }

    /// <summary>
    /// Represents the AuthorizationCodeChargeRequest class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.ChargeRequest" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.ChargeRequest" />
    public class AuthorizationCodeChargeRequest : ChargeRequest
    {
        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the amount in kobo.
        /// </summary>
        /// <value>The amount in kobo.</value>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the authorization code.
        /// </summary>
        /// <value>The authorization code.</value>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets the pin number.
        /// </summary>
        /// <value>The pin number.</value>
        [JsonProperty("pin")]
        public string Pin { get; set; }
    }

    /// <summary>
    /// Represents a ChargeResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.HasRawResponse" />
    public class ChargeResponse : HasRawResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChargeResponse"/> request was successful.
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
        /// Gets or sets the response data.
        /// </summary>
        /// <value>The response data.</value>
        [JsonProperty("data")]
        public Charge.Data Data { get; set; }
    }
}
