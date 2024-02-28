namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents an ICustomersApi interface.
    /// </summary>
    public interface ICustomersApi
    {
        /// <summary>
        /// Creates the customer using specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CustomerCreateResponse.</returns>
        CustomerCreateResponse Create(CustomerCreateRequest request);
        /// <summary>
        /// Creates the customer using specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>CustomerCreateResponse.</returns>
        CustomerCreateResponse Create(string email);
        /// <summary>
        /// Returns the list of customers.
        /// </summary>
        /// <param name="perPage">The number of customers per page.</param>
        /// <param name="page">The page number.</param>
        /// <returns>CustomerListResponse.</returns>
        CustomerListResponse List(int perPage = 50, int page = 1);
        /// <summary>
        /// Fetches the specified customer using the identifier or customer code.
        /// </summary>
        /// <param name="customerIdOrCustomerCode">The customer's identifier or customer code.</param>
        /// <returns>CustomerFetchResponse.</returns>
        CustomerFetchResponse Fetch(string customerIdOrCustomerCode);

        /// <summary>
        /// Updates the specified customer's record using the identifier or code.
        /// </summary>
        /// <param name="customerIdOrCode">The customer identifier or code.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phone">The phone number.</param>
        /// <returns>CustomerUpdateResponse.</returns>
        CustomerUpdateResponse Update(string customerIdOrCode, string firstName = null, string lastName = null,
            string phone = null);

        /// <summary>
        /// Updates the specified customer's record using the identifier or code.
        /// </summary>
        /// <param name="customerIdOrCode">The customer identifier or code.</param>
        /// <param name="request">The request.</param>
        /// <returns>CustomerUpdateResponse.</returns>
        CustomerUpdateResponse Update(string customerIdOrCode, CustomerUpdateRequest request);
        /// <summary>
        /// Sets the risk action to take on a customer ('allow' to white-list and 'deny' to blacklist).
        /// </summary>
        /// <param name="customerIdCodeOrEmail">The customer identifier code or email.</param>
        /// <param name="riskAction">The risk action.</param>
        /// <returns>CustomerSetRiskActionResponse.</returns>
        CustomerSetRiskActionResponse SetRiskAction(string customerIdCodeOrEmail, string riskAction);
        /// <summary>
        /// White-lists the customer.
        /// </summary>
        /// <param name="customerIdCodeOrEmail">The customer identifier code or email.</param>
        /// <returns>CustomerSetRiskActionResponse.</returns>
        CustomerSetRiskActionResponse WhiteList(string customerIdCodeOrEmail);
        /// <summary>
        /// Blacklists the customer.
        /// </summary>
        /// <param name="customerIdCodeOrEmail">The customer identifier code or email.</param>
        /// <returns>CustomerSetRiskActionResponse.</returns>
        CustomerSetRiskActionResponse BlackList(string customerIdCodeOrEmail);
    }
}