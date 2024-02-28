using System;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents a TransactionsApi class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.ITransactionsApi" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.ITransactionsApi" />
    internal class TransactionsApi : ITransactionsApi
    {
        /// <summary>
        /// The API
        /// </summary>
        private readonly PayStackApi _api;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsApi"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        internal TransactionsApi(PayStackApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Initializes the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="reference">The reference.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <param name="currency">The currency.</param>
        /// <returns>TransactionInitializeResponse.</returns>
        public TransactionInitializeResponse Initialize(string email, int amount, string reference = null, bool makeReferenceUnique = false, string currency = "NGN")
            => Initialize(new TransactionInitializeRequest { Reference = reference, Email = email, AmountInKobo = amount, Currency = currency }, makeReferenceUnique);

        /// <summary>
        /// Initializes the transaction API.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>TransactionInitializeResponse.</returns>
        public TransactionInitializeResponse Initialize(TransactionInitializeRequest request, bool makeReferenceUnique = false)
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference = $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<TransactionInitializeResponse, TransactionInitializeRequest>("transaction/initialize", request);
        }


        /// <summary>
        /// Verifies the transaction using the specified reference number.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <returns>TransactionVerifyResponse.</returns>
        public TransactionVerifyResponse Verify(string reference) =>
                _api.Get<TransactionVerifyResponse>($"transaction/verify/{reference}");

        /// <summary>
        /// Lists the transactions using the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>TransactionListResponse.</returns>
        public TransactionListResponse List(TransactionListRequest request = null) =>
            _api.Get<TransactionListResponse, TransactionListRequest>("transaction", request);

        /// <summary>
        /// Fetches the transaction with the specified transaction identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>TransactionFetchResponse.</returns>
        public TransactionFetchResponse Fetch(string transactionId) =>
            _api.Get<TransactionFetchResponse>($"transaction/{transactionId}");

        /// <summary>
        /// Gets the transaction Timeline with the specified transaction identifier or reference number.
        /// </summary>
        /// <param name="transactionIdOrReference">The transaction identifier or reference number.</param>
        /// <returns>TransactionTimelineResponse.</returns>
        public TransactionTimelineResponse Timeline(string transactionIdOrReference) =>
            _api.Get<TransactionTimelineResponse>($"transaction/timeline/{transactionIdOrReference}");

        /// <summary>
        /// Gets the total amount received on your account.
        /// </summary>
        /// <param name="from">The lower bound of date range. Leave undefined to show totals from day one.</param>
        /// <param name="to">pper bound of date range. Leave undefined to show totals till date.</param>
        /// <returns>TransactionTotalsResponse.</returns>
        public TransactionTotalsResponse Totals(DateTime? from = null, DateTime? to = null) =>
            _api.Get<TransactionTotalsResponse, TransactionTotalsRequest>(
                "transaction/totals", new TransactionTotalsRequest { From = from, To = to }
            );

        /// <summary>
        /// Exports the transactions.
        /// </summary>
        /// <param name="from">The lower bound of date range. Leave undefined to export transactions from day one.</param>
        /// <param name="to">pper bound of date range. Leave undefined to export transactions till date.</param>
        /// <param name="settled">if set to <c>true</c> [settled].</param>
        /// <param name="paymentPage">The payment page.</param>
        /// <returns>TransactionExportResponse.</returns>
        public TransactionExportResponse Export(DateTime? from = null, DateTime? to = null,
            bool settled = false, string paymentPage = null) =>
            _api.Get<TransactionExportResponse, TransactionExportRequest>(
                "transaction/export",
                new TransactionExportRequest { From = from, To = to, Settled = settled, Payment_Page = paymentPage }
            );

        /// <summary>
        /// Performs charge authorization. All authorizations marked as reusable can be charged
        /// with this endpoint whenever you need to receive payments.
        /// </summary>
        /// <param name="authorizationCode">The authorization code.</param>
        /// <param name="email">The email.</param>
        /// <param name="amountInKobo">The amount in kobo.</param>
        /// <param name="reference">The reference number.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeAuthorizationResponse.</returns>
        public ChargeAuthorizationResponse ChargeAuthorization(string authorizationCode, string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false) =>
            ChargeAuthorization(new ChargeAuthorizationRequest
            {
                Reference = reference,
                AuthorizationCode = authorizationCode,
                Email = email,
                AmountInKobo = amountInKobo
            }, makeReferenceUnique);

        /// <summary>
        /// Performs charge authorization. All authorizations marked as reusable can be charged
        /// with this endpoint whenever you need to receive payments.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeAuthorizationResponse.</returns>
        public ChargeAuthorizationResponse ChargeAuthorization(ChargeAuthorizationRequest request, bool makeReferenceUnique = false)
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference = $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<ChargeAuthorizationResponse, ChargeAuthorizationRequest>(
                "transaction/charge_authorization", request
            );
        }

        /// <summary>
        /// Requests re-authorization. We do not activate authorizations for recurring billing until the
        /// first time we are able to bill that card successfully. Reauthorizing with the issuing
        /// bank may ensure a successful transaction.
        /// </summary>
        /// <param name="authorizationCode">The authorization code.</param>
        /// <param name="email">The email address.</param>
        /// <param name="amountInKobo">The amount in kobo.</param>
        /// <param name="reference">The reference number.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ReAuthorizationResponse.</returns>
        public ReAuthorizationResponse RequestReAuthorization(string authorizationCode, string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false) =>
            RequestReAuthorization(new ReAuthorizationRequest
            {
                AuthorizationCode = authorizationCode,
                Email = email,
                AmountInKobo = amountInKobo,
                Reference = reference
            }, makeReferenceUnique);

        /// <summary>
        /// Requests re-authorization. We do not activate authorizations for recurring billing until the
        /// first time we are able to bill that card successfully. Reauthorizing with the issuing
        /// bank may ensure a successful transaction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ReAuthorizationResponse.</returns>
        public ReAuthorizationResponse RequestReAuthorization(ReAuthorizationRequest request, bool makeReferenceUnique = false)
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference = $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<ReAuthorizationResponse, ReAuthorizationRequest>(
                "transaction/request_reauthorization", request
            );
        }

        /// <summary>
        /// Checks the authorization. All mastercard and visa authorizations can be checked with
        /// this endpoint to know if they have funds for the payment you seek.
        /// </summary>
        /// <param name="authorizationCode">The authorization code.</param>
        /// <param name="email">The email address.</param>
        /// <param name="amountInKobo">The amount in kobo.</param>
        /// <returns>CheckAuthorizationResponse.</returns>
        public CheckAuthorizationResponse CheckAuthorization(string authorizationCode, string email, int amountInKobo) =>
            CheckAuthorization(new CheckAuthorizationRequest
            {
                AuthorizationCode = authorizationCode,
                Email = email,
                AmountInKobo = amountInKobo
            });

        /// <summary>
        /// Checks the authorization. All mastercard and visa authorizations can be checked with
        /// this endpoint to know if they have funds for the payment you seek.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CheckAuthorizationResponse.</returns>
        public CheckAuthorizationResponse CheckAuthorization(CheckAuthorizationRequest request) =>
            _api.Post<CheckAuthorizationResponse, CheckAuthorizationRequest>(
                "transaction/check_authorization", request
            );
    }
}