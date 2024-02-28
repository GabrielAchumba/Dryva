namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the CustomersApi class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.ICustomersApi" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.ICustomersApi" />
    public class CustomersApi : ICustomersApi
    {
        /// <summary>
        /// The API
        /// </summary>
        private readonly PayStackApi _api;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersApi"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        public CustomersApi(PayStackApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Creates the customer using specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CustomerCreateResponse.</returns>
        public CustomerCreateResponse Create(CustomerCreateRequest request) =>
            _api.Post<CustomerCreateResponse, CustomerCreateRequest>("customer", request);

        /// <summary>
        /// Creates the customer using specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>CustomerCreateResponse.</returns>
        public CustomerCreateResponse Create(string email) => Create(new CustomerCreateRequest {Email = email});

        /// <summary>
        /// Returns the list of customers.
        /// </summary>
        /// <param name="perPage">The number of customers per page.</param>
        /// <param name="page">The page number.</param>
        /// <returns>CustomerListResponse.</returns>
        public CustomerListResponse List(int perPage = 50, int page = 1) =>
            _api.Get<CustomerListResponse, CustomerListRequest>("customer",
                new CustomerListRequest {Page = page, PerPage = perPage});

        /// <summary>
        /// Fetches the specified customer using the identifier or customer code.
        /// </summary>
        /// <param name="customerIdOrCustomerCode">The customer's identifier or customer code.</param>
        /// <returns>CustomerFetchResponse.</returns>
        public CustomerFetchResponse Fetch(string customerIdOrCustomerCode) =>
            _api.Get<CustomerFetchResponse>($"customer/{customerIdOrCustomerCode}");

        /// <summary>
        /// Updates the specified customer's record using the identifier or code.
        /// </summary>
        /// <param name="customerIdOrCode">The customer identifier or code.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phone">The phone number.</param>
        /// <returns>CustomerUpdateResponse.</returns>
        public CustomerUpdateResponse Update(string customerIdOrCode, string firstName = null, string lastName = null,
            string phone = null)
            =>
                Update(customerIdOrCode,
                    new CustomerUpdateRequest {FirstName = firstName, LastName = lastName, Phone = phone});

        /// <summary>
        /// Updates the specified customer's record using the identifier or code.
        /// </summary>
        /// <param name="customerIdOrCode">The customer identifier or code.</param>
        /// <param name="request">The request.</param>
        /// <returns>CustomerUpdateResponse.</returns>
        public CustomerUpdateResponse Update(string customerIdOrCode, CustomerUpdateRequest request) =>
            _api.Put<CustomerUpdateResponse, CustomerUpdateRequest>($"customer/{customerIdOrCode}", request);

        /// <summary>
        /// Sets the risk action to take on a customer ('allow' to white-list and 'deny' to blacklist).
        /// </summary>
        /// <param name="customerIdCodeOrEmail">The customer identifier code or email.</param>
        /// <param name="riskAction">The risk action.</param>
        /// <returns>CustomerSetRiskActionResponse.</returns>
        public CustomerSetRiskActionResponse SetRiskAction(string customerIdCodeOrEmail, string riskAction) =>
            _api.Post<CustomerSetRiskActionResponse, CustomerSetRiskActionRequest>(
                "customer/set_risk_action",
                new CustomerSetRiskActionRequest {Customer = customerIdCodeOrEmail, RiskAction = riskAction}
            );

        /// <summary>
        /// White-lists the customer.
        /// </summary>
        /// <param name="customerIdCodeOrEmail">The customer identifier code or email.</param>
        /// <returns>CustomerSetRiskActionResponse.</returns>
        public CustomerSetRiskActionResponse WhiteList(string customerIdCodeOrEmail) =>
            SetRiskAction(customerIdCodeOrEmail, "allow");

        /// <summary>
        /// Blacklists the customer.
        /// </summary>
        /// <param name="customerIdCodeOrEmail">The customer identifier code or email.</param>
        /// <returns>CustomerSetRiskActionResponse.</returns>
        public CustomerSetRiskActionResponse BlackList(string customerIdCodeOrEmail) =>
            SetRiskAction(customerIdCodeOrEmail, "deny");
    }
}