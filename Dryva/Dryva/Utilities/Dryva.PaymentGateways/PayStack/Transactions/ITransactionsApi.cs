using System;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the ITransactionsApi interface.
    /// </summary>
    public interface ITransactionsApi
    {
        /// <summary>
        /// Initializes the transaction API.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <param name="amountInKobo">The amount in kobo.</param>
        /// <param name="reference">The reference number.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <param name="currency">The currency.</param>
        /// <returns>TransactionInitializeResponse.</returns>
        TransactionInitializeResponse Initialize(string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false, string currency = "NGN");
        /// <summary>
        /// Initializes the transaction API.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>TransactionInitializeResponse.</returns>
        TransactionInitializeResponse Initialize(TransactionInitializeRequest request, bool makeReferenceUnique = false);
        /// <summary>
        /// Verifies the transaction using the specified reference number.
        /// </summary>
        /// <param name="reference">The reference number.</param>
        /// <returns>TransactionVerifyResponse.</returns>
        TransactionVerifyResponse Verify(string reference);
        /// <summary>
        /// Lists the transactions using the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>TransactionListResponse.</returns>
        TransactionListResponse List(TransactionListRequest request = null);
        /// <summary>
        /// Fetches the transaction with the specified transaction identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>TransactionFetchResponse.</returns>
        TransactionFetchResponse Fetch(string transactionId);
        /// <summary>
        /// Gets the transaction Timeline with the specified transaction identifier or reference number.
        /// </summary>
        /// <param name="transactionIdOrReference">The transaction identifier or reference number.</param>
        /// <returns>TransactionTimelineResponse.</returns>
        TransactionTimelineResponse Timeline(string transactionIdOrReference);
        /// <summary>
        /// Gets the total amount received on your account.
        /// </summary>
        /// <param name="from">The lower bound of date range. Leave undefined to show totals from day one.</param>
        /// <param name="to">pper bound of date range. Leave undefined to show totals till date.</param>
        /// <returns>TransactionTotalsResponse.</returns>
        TransactionTotalsResponse Totals(DateTime? from = null, DateTime? to = null);
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
        ChargeAuthorizationResponse ChargeAuthorization(string authorizationCode, string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false);
        /// <summary>
        /// Performs charge authorization. All authorizations marked as reusable can be charged
        /// with this endpoint whenever you need to receive payments.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ChargeAuthorizationResponse.</returns>
        ChargeAuthorizationResponse ChargeAuthorization(ChargeAuthorizationRequest request, bool makeReferenceUnique = false);
        /// <summary>
        /// Exports the transactions.
        /// </summary>
        /// <param name="from">The lower bound of date range. Leave undefined to export transactions from day one.</param>
        /// <param name="to">pper bound of date range. Leave undefined to export transactions till date.</param>
        /// <param name="settled">if set to <c>true</c> [settled].</param>
        /// <param name="paymentPage">The payment page.</param>
        /// <returns>TransactionExportResponse.</returns>
        TransactionExportResponse Export(DateTime? from = null, DateTime? to = null,
            bool settled = false, string paymentPage = null);
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
        ReAuthorizationResponse RequestReAuthorization(string authorizationCode, string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false);
        /// <summary>
        /// Requests re-authorization. We do not activate authorizations for recurring billing until the
        /// first time we are able to bill that card successfully. Reauthorizing with the issuing
        /// bank may ensure a successful transaction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="makeReferenceUnique">if set to <c>true</c> [make reference unique].</param>
        /// <returns>ReAuthorizationResponse.</returns>
        ReAuthorizationResponse RequestReAuthorization(ReAuthorizationRequest request, bool makeReferenceUnique = false);

        /// <summary>
        /// Checks the authorization. All mastercard and visa authorizations can be checked with
        /// this endpoint to know if they have funds for the payment you seek.
        /// </summary>
        /// <param name="authorizationCode">The authorization code.</param>
        /// <param name="email">The email address.</param>
        /// <param name="amountInKobo">The amount in kobo.</param>
        /// <returns>CheckAuthorizationResponse.</returns>
        CheckAuthorizationResponse CheckAuthorization(string authorizationCode, string email, int amountInKobo);
        /// <summary>
        /// Checks the authorization. All mastercard and visa authorizations can be checked with
        /// this endpoint to know if they have funds for the payment you seek.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CheckAuthorizationResponse.</returns>
        CheckAuthorizationResponse CheckAuthorization(CheckAuthorizationRequest request);
    }
}