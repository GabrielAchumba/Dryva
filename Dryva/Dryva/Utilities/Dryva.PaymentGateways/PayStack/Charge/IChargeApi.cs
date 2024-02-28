using System;
using Dryva.PaymentGateways.PayStack;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents an IChargeApi interface. When implemented, can be used to send
    /// card details or bank details or authorization code to start a charge.
    /// </summary>
    public interface IChargeApi
    {
        /// <summary>
        /// Generates a <see cref="ChargeTokenizeResponse"/> object for the supplied data.
        /// </summary>
        /// <param name="email">The customer email.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="cardCvv">The card CVV.</param>
        /// <param name="cardExpiryMonth">The card expiry month.</param>
        /// <param name="cardExpiryYear">The card expiry year.</param>
        /// <returns>ChargeTokenizeResponse.</returns>
        ChargeTokenizeResponse Tokenize(string email, string cardNumber, string cardCvv, string cardExpiryMonth, string cardExpiryYear);

        /// <summary>
        /// Charges the customer's bank account using the specified information.
        /// </summary>
        /// <param name="email">The customer email.</param>
        /// <param name="amount">The amount in kobo.</param>
        /// <param name="bankCode">The bank code.</param>
        /// <param name="bankAccountNumber">The bank account number.</param>
        /// <param name="reference">The reference number.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse ChargeBank(string email, string amount, string bankCode, string bankAccountNumber, string reference = null, bool makeReferenceUnique = false);

        /// <summary>
        /// Charges the customer's bank account using the specified charge request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse ChargeBank(BankChargeRequest request, bool makeReferenceUnique = false);

        /// <summary>
        /// Charges the customer's card using the specified information.
        /// </summary>
        /// <param name="email">The customer email.</param>
        /// <param name="amount">The amount in kobo.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="cardCvv">The card CVV.</param>
        /// <param name="cardExpiryMonth">The card expiry month.</param>
        /// <param name="cardExpiryYear">The card expiry year.</param>
        /// <param name="pin">The pin number.</param>
        /// <param name="reference">The reference number.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse ChargeCard(string email, string amount, string cardNumber, string cardCvv, string cardExpiryMonth, string cardExpiryYear, string pin, string reference = null, bool makeReferenceUnique = false);

        /// <summary>
        /// Charges the customer's card using the specified charge request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse ChargeCard(CardChargeRequest request, bool makeReferenceUnique = false);

        /// <summary>
        /// Charges the customer's authorization code using the specified information.
        /// </summary>
        /// <param name="email">The customer email.</param>
        /// <param name="amount">The amount in kobo.</param>
        /// <param name="authorizationCode">The authorization code.</param>
        /// <param name="pin">The pin number.</param>
        /// <param name="reference">The reference number.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse ChargeAuthorizationCode(string email, string amount, string authorizationCode, string pin, string reference = null, bool makeReferenceUnique = false);

        /// <summary>
        /// Charges the customer's authorization code using the specified charge request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse ChargeAuthorizationCode(AuthorizationCodeChargeRequest request, bool makeReferenceUnique = false);

        /// <summary>
        /// Submits the pin to continue a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="pin">The pin number.</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse SubmitPIN(string reference, string pin);

        /// <summary>
        /// Submits the OTP to complete a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="otp">The OTP.</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse SubmitOTP(string reference, string otp);

        /// <summary>
        /// Submits the customer's phone number when requested during a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="phone">The customer's phone number.</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse SubmitPhone(string reference, string phone);

        /// <summary>
        /// Submits the customer's birthday when requested during a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="birthday">The customer's birthday.</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse SubmitBirthday(string reference, DateTime birthday);

        /// <summary>
        /// Checks the pending charge.
        /// When you get "pending" as a charge status or if there was an exception when calling any
        /// of the /charge endpoints, wait 10 seconds or more, then make a check to see if its status
        /// has changed. Don't call too early as you may get a lot more pending than you should.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <returns>ChargeResponse.</returns>
        ChargeResponse CheckPendingCharge(string reference);

    }
}