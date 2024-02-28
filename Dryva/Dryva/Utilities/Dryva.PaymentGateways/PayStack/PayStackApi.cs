using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the IPayStackApi interface.
    /// </summary>
    public interface IPayStackApi
    {
        /// <summary>
        /// Gets the sub accounts API interface.
        /// </summary>
        /// <value>The sub accounts API interface.</value>
        ISubAccountApi SubAccounts { get; }
        /// <summary>
        /// Gets the transactions API interface.
        /// </summary>
        /// <value>The transactions API interface.</value>
        ITransactionsApi Transactions { get; }
        /// <summary>
        /// Gets the customers API interface.
        /// </summary>
        /// <value>The customers API interface.</value>
        ICustomersApi Customers { get; }
        /// <summary>
        /// Gets the settlements API interface.
        /// </summary>
        /// <value>The settlements API interface.</value>
        ISettlementsApi Settlements { get; }
        /// <summary>
        /// Gets the transfers API interface.
        /// </summary>
        /// <value>The transfers API interface.</value>
        ITransfersApi Transfers { get; }
    }

    /// <summary>
    /// Represents the PayStackApi class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.IPayStackApi" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.IPayStackApi" />
    public class PayStackApi : IPayStackApi
    {
        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayStackApi"/> class.
        /// </summary>
        /// <param name="secretKey">The secret key.</param>
        public PayStackApi(string secretKey)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient { BaseAddress = new Uri("https://api.paystack.co/") };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Transactions = new TransactionsApi(this);
            Customers = new CustomersApi(this);
            SubAccounts = new SubAccountApi(this);
            Settlements = new SettlementsApi(this);
            Miscellaneous = new MiscellaneousApi(this);
            Transfers = new TransfersApi(this);
            Charge = new ChargeApi(this);
        }

        /// <summary>
        /// Gets the JSON serializer settings.
        /// </summary>
        /// <value>The JSON serializer settings.</value>
        public static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
        };

        /// <summary>
        /// Gets the sub accounts API interface.
        /// </summary>
        /// <value>The sub accounts API interface.</value>
        public ISubAccountApi SubAccounts { get; }

        /// <summary>
        /// Gets the transactions API interface.
        /// </summary>
        /// <value>The transactions API interface.</value>
        public ITransactionsApi Transactions { get; }

        /// <summary>
        /// Gets the customers API interface.
        /// </summary>
        /// <value>The customers API interface.</value>
        public ICustomersApi Customers { get; }

        /// <summary>
        /// Gets the settlements API interface.
        /// </summary>
        /// <value>The settlements API interface.</value>
        public ISettlementsApi Settlements { get; }

        /// <summary>
        /// Gets the miscellaneous.
        /// </summary>
        /// <value>The miscellaneous.</value>
        public IMiscellaneousApi Miscellaneous { get; }

        /// <summary>
        /// Gets the transfers API interface.
        /// </summary>
        /// <value>The transfers API interface.</value>
        public ITransfersApi Transfers { get; }

        /// <summary>
        /// Gets the charge API interface.
        /// </summary>
        /// <value>The charge.</value>
        public IChargeApi Charge { get; }


        /// <summary>
        /// Resolves the card bin.
        /// </summary>
        /// <param name="cardBin">The card bin.</param>
        /// <returns>ResolveCardBinResponse.</returns>
        [Obsolete("Use Dryva.PaymentGateways.PayStack.Miscellaneous.ResolveCardBin(cardBin) instead.")]
        public ResolveCardBinResponse ResolveCardBin(string cardBin) => Miscellaneous.ResolveCardBin(cardBin);

        #region Utility Methods

        /// <summary>
        /// Prepares the request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        private string PrepareRequest<T>(T request)
        {
            (request as IPreparable)?.Prepare();

            var requestBody = JsonConvert.SerializeObject(request, Formatting.Indented, SerializerSettings);
            return requestBody;
        }

        /// <summary>
        /// Performs POST operation on the specified relative URL.
        /// </summary>
        /// <typeparam name="TR">The type of the response.</typeparam>
        /// <typeparam name="T">The type of the request.</typeparam>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="request">The request.</param>
        /// <returns>TR.</returns>
        internal TR Post<TR, T>(string relativeUrl, T request)
        {
            var rawJson = _client.PostAsync(
                    relativeUrl,
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result;

            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        /// <summary>
        /// Parses the raw JSON and resolve its metadata.
        /// </summary>
        /// <typeparam name="TR">The type of the return value.</typeparam>
        /// <param name="rawJson">The raw json.</param>
        /// <returns>TR.</returns>
        private static TR ParseAndResolveMetadata<TR>(ref string rawJson)
        {
            var jo = JObject.Parse(rawJson);
            var data = jo["data"];
            if (data != null && !(data is JArray) && data["metadata"] != null)
            {
                var metadata = data["metadata"];
                jo["data"]["metadata"] = JsonConvert.DeserializeObject<JObject>(metadata.ToString());
            }

            rawJson = jo.ToString();

            var response = JsonConvert.DeserializeObject<TR>(rawJson);

            if (typeof(IHasRawResponse).IsAssignableFrom(typeof(TR)))
                (response as IHasRawResponse).RawJson = rawJson;

            return response;
        }

        /// <summary>
        /// Performs PUT operation on the specified relative URL.
        /// </summary>
        /// <typeparam name="TR">The type of the response.</typeparam>
        /// <typeparam name="T">The type of the request.</typeparam>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="request">The request.</param>
        /// <returns>TR.</returns>
        internal TR Put<TR, T>(string relativeUrl, T request)
        {
            var rawJson = _client.PutAsync(
                    relativeUrl,
                    new StringContent(PrepareRequest(request))
                ).Result.Content.ReadAsStringAsync().Result;

            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        /// <summary>
        /// Performs GET operation the specified relative URL.
        /// </summary>
        /// <typeparam name="TR">The type of the response.</typeparam>
        /// <typeparam name="T">The type of the request.</typeparam>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="request">The request.</param>
        /// <returns>TR.</returns>
        internal TR Get<TR, T>(string relativeUrl, T request)
            where TR : class
        {
            var preparable = request as IPreparable;

            var queryString = "";
            if (request != null)
                queryString = "?" + request.ToQueryString();

            if (preparable != null)
                preparable.Prepare();

            var rawJson = _client.GetAsync(relativeUrl + queryString).Result.Content.ReadAsStringAsync().Result;
            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        /// <summary>
        /// Performs GET operation on the specified relative URL.
        /// </summary>
        /// <typeparam name="TR">The type of the response.</typeparam>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns>TR.</returns>
        internal TR Get<TR>(string relativeUrl)
        {
            var rawJson = _client.GetAsync(relativeUrl).Result.Content.ReadAsStringAsync().Result;
            return ParseAndResolveMetadata<TR>(ref rawJson);
        }

        #endregion
    }
}