using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dryva.PaymentGateways.Rave
{
    /// <summary>
    /// Class WebHookPayLoad.
    /// </summary>
    public class WebHookPayLoad
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the transaction reference.
        /// </summary>
        /// <value>The transaction reference.</value>
        [JsonProperty("txRef")]
        public string TransactionReference { get; set; }
        /// <summary>
        /// Gets or sets the flow reference.
        /// </summary>
        /// <value>The flow reference.</value>
        [JsonProperty("flwRef")]
        public string FlowReference { get; set; }
        /// <summary>
        /// Gets or sets the order reference.
        /// </summary>
        /// <value>The order reference.</value>
        [JsonProperty("orderRef")]
        public string OrderReference { get; set; }
        /// <summary>
        /// Gets or sets the payment plan.
        /// </summary>
        /// <value>The payment plan.</value>
        [JsonProperty("paymentPlan")]
        public string PaymentPlan { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the charged amount.
        /// </summary>
        /// <value>The charged amount.</value>
        [JsonProperty("charged_amount")]
        public decimal ChargedAmount { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>The ip address.</value>
        [JsonProperty("IP")]
        public string IPAddress { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public Entity Entity { get; set; }
    }

    /// <summary>
    /// Class Customer.
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
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonProperty("customertoken")]
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the deleted at.
        /// </summary>
        /// <value>The deleted at.</value>
        [JsonProperty("deletedAt")]
        public DateTime? DeletedAt { get; set; }
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        [JsonProperty("AccountId")]
        public int AccountId { get; set; }
    }

    /// <summary>
    /// Class Entity.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the card6.
        /// </summary>
        /// <value>The card6.</value>
        [JsonProperty("card6")]
        public string Card6 { get; set; }
        /// <summary>
        /// Gets or sets the card last4.
        /// </summary>
        /// <value>The card last4.</value>
        [JsonProperty("card_last4")]
        public string CardLast4 { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
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
    }

    /// <summary>
    /// Class CardToken.
    /// </summary>
    public class CardToken
    {
        /// <summary>
        /// Gets or sets the embed token.
        /// </summary>
        /// <value>The embed token.</value>
        [JsonProperty("embedtoken")]
        public string EmbedToken { get; set; }
        /// <summary>
        /// Gets or sets the short code.
        /// </summary>
        /// <value>The short code.</value>
        [JsonProperty("shortcode")]
        public string ShortCode { get; set; }
        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>The expiry.</value>
        [JsonProperty("expiry")]
        public string Expiry { get; set; }
    }
    /// <summary>
    /// Class Card.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the expiry month.
        /// </summary>
        /// <value>The expiry month.</value>
        [JsonProperty("expirymonth")]
        public int ExpiryMonth { get; set; }
        /// <summary>
        /// Gets or sets the expiry year.
        /// </summary>
        /// <value>The expiry year.</value>
        [JsonProperty("expiryyear")]
        public int ExpiryYear { get; set; }
        /// <summary>
        /// Gets or sets the card bin.
        /// </summary>
        /// <value>The card bin.</value>
        [JsonProperty("cardBIN")]
        public string CardBin { get; set; }
        /// <summary>
        /// Gets or sets the last4 digits.
        /// </summary>
        /// <value>The last4 digits.</value>
        [JsonProperty("last4digits")]
        public string Last4Digits { get; set; }
        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        /// <value>The brand.</value>
        [JsonProperty("brand")]
        public string Brand { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the life time token.
        /// </summary>
        /// <value>The life time token.</value>
        [JsonProperty("life_time_token")]
        public string LifeTimeToken { get; set; }

        /// <summary>
        /// Gets or sets the card tokens.
        /// </summary>
        /// <value>The card tokens.</value>
        [JsonProperty("card_tokens")]
        public CardToken[] CardTokens { get; set; }
    }
    /// <summary>
    /// Class Meta.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier.</value>
        [JsonProperty("getpaidTransactionId")]
        public int TransactionId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("metaname")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("metavalue")]
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the deleted at.
        /// </summary>
        /// <value>The deleted at.</value>
        [JsonProperty("deletedAt")]
        public DateTime? DeletedAt { get; set; }
    }
    /// <summary>
    /// Class VerifyResponse.
    /// </summary>
    public class VerifyResponse
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("data")]
        public VerifyResponseData Data { get; set; }
    }

    /// <summary>
    /// Class VerifyResponseData.
    /// </summary>
    public class VerifyResponseData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("txid")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the transaction reference.
        /// </summary>
        /// <value>The transaction reference.</value>
        [JsonProperty("txref")]
        public string TransactionReference { get; set; }
        /// <summary>
        /// Gets or sets the flow reference.
        /// </summary>
        /// <value>The flow reference.</value>
        [JsonProperty("flwref")]
        public string FlowReference { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the charge code.
        /// </summary>
        /// <value>The charge code.</value>
        [JsonProperty("chargecode")]
        public string ChargeCode { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Gets or sets the payment gateway fee.
        /// </summary>
        /// <value>The payment gateway fee.</value>
        [JsonProperty("appfee")]
        public decimal PaymentGatewayFee { get; set; }
        /// <summary>
        /// Gets or sets the charge message.
        /// </summary>
        /// <value>The charge message.</value>
        [JsonProperty("chargemessage")]
        public string ChargeMessage { get; set; }
        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        [JsonProperty("paymentid")]
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the card.
        /// </summary>
        /// <value>The card.</value>
        [JsonProperty("card")]
        public Card Card { get; set; }
        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>The metadata.</value>
        [JsonProperty("meta")]
        public Meta[] Metadata { get; set; }
    }
}
