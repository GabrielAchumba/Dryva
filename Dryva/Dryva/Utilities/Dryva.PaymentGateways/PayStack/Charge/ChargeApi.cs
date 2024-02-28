using System;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents a ChargeApi class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.IChargeApi" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.IChargeApi" />
    public class ChargeApi : IChargeApi
    {
        /// <summary>
        /// The API
        /// </summary>
        private readonly PayStackApi _api;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeApi"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        public ChargeApi(PayStackApi api)
        {
            this._api = api;
        }

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
        public ChargeResponse ChargeAuthorizationCode(string email, string amount, string authorizationCode, string pin, string reference = null, bool makeReferenceUnique = false) =>
            ChargeAuthorizationCode(
                new AuthorizationCodeChargeRequest
                {
                    Email = email,
                    Amount = amount,
                    AuthorizationCode = authorizationCode,
                    Pin = pin,
                    Reference = makeReferenceUnique && reference != null ?
                        $"{reference}-{Guid.NewGuid().ToString().Substring(0, 8)}" : reference
                },
                makeReferenceUnique
            );

        /// <summary>
        /// Charges the customer's authorization code using the specified charge request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse ChargeAuthorizationCode(AuthorizationCodeChargeRequest request, bool makeReferenceUnique = false)
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference = $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<ChargeResponse, AuthorizationCodeChargeRequest>("charge", request);
        }

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
        public ChargeResponse ChargeBank(string email, string amount, string bankCode, string bankAccountNumber, string reference = null, bool makeReferenceUnique = false) =>
            ChargeBank(
                new BankChargeRequest
                {
                    Email = email,
                    Amount = amount,
                    Bank = new Bank
                    {
                        Code = bankCode,
                        AccountNumber = bankAccountNumber
                    },
                    Reference = reference
                },
                makeReferenceUnique
            );

        /// <summary>
        /// Charges the customer's bank account using the specified charge request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse ChargeBank(BankChargeRequest request, bool makeReferenceUnique = false)
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference = $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";

            return _api.Post<ChargeResponse, BankChargeRequest>("charge", request);
        }

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
        public ChargeResponse ChargeCard(string email, string amount, string cardNumber, string cardCvv, string cardExpiryMonth, string cardExpiryYear, string pin, string reference = null, bool makeReferenceUnique = false) =>
            ChargeCard(
                new CardChargeRequest
                {
                    Email = email,
                    Amount = amount,
                    Card = new Card
                    {
                        Number = cardNumber,
                        Cvv = cardCvv,
                        ExpiryMonth = cardExpiryMonth,
                        ExpiryYear = cardExpiryYear
                    },
                    Pin = pin,
                    Reference = reference
                }
            );

        /// <summary>
        /// Charges the customer's card using the specified charge request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse ChargeCard(CardChargeRequest request, bool makeReferenceUnique = false)
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference = $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";

            return _api.Post<ChargeResponse, CardChargeRequest>("charge", request);
        }

        /// <summary>
        /// Checks the pending charge.
        /// When you get "pending" as a charge status or if there was an exception when calling any
        /// of the /charge endpoints, wait 10 seconds or more, then make a check to see if its status
        /// has changed. Don't call too early as you may get a lot more pending than you should.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse CheckPendingCharge(string reference) =>
            _api.Get<ChargeResponse>($"charge/{reference}");

        /// <summary>
        /// Submits the customer's birthday when requested during a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="birthday">The customer's birthday.</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse SubmitBirthday(string reference, DateTime birthday) => _api.Post<ChargeResponse, dynamic>("charge/submit_birthday", new
        {
            birthday = birthday,
            reference = reference
        });

        /// <summary>
        /// Submits the OTP to complete a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="otp">The OTP.</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse SubmitOTP(string reference, string otp) => _api.Post<ChargeResponse, dynamic>("charge/submit_otp", new
        {
            otp = otp,
            reference = reference
        });

        /// <summary>
        /// Submits the customer's phone number when requested during a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="phone">The customer's phone number.</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse SubmitPhone(string reference, string phone) => _api.Post<ChargeResponse, dynamic>("charge/submit_phone", new
        {
            phone = phone,
            reference = reference
        });

        /// <summary>
        /// Submits the pin to continue a charge.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <param name="pin">The pin number.</param>
        /// <returns>ChargeResponse.</returns>
        public ChargeResponse SubmitPIN(string reference, string pin) => _api.Post<ChargeResponse, dynamic>("charge/submit_pin", new
        {
            pin = pin,
            reference = reference
        });

        /// <summary>
        /// Generates a <see cref="ChargeTokenizeResponse" /> object for the supplied data.
        /// </summary>
        /// <param name="email">The customer email.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="cardCvv">The card CVV.</param>
        /// <param name="cardExpiryMonth">The card expiry month.</param>
        /// <param name="cardExpiryYear">The card expiry year.</param>
        /// <returns>ChargeTokenizeResponse.</returns>
        public ChargeTokenizeResponse Tokenize(string email, string cardNumber, string cardCvv, string cardExpiryMonth, string cardExpiryYear) =>
            _api.Post<ChargeTokenizeResponse, dynamic>("charge/tokenize", new
            {
                email = email,
                card = new
                {
                    number = cardNumber,
                    cvv = cardCvv,
                    expiry_month = cardExpiryMonth,
                    expiry_year = cardExpiryYear
                }
            });
    }
}