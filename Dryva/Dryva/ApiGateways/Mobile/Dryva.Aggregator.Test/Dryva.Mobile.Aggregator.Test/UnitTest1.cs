using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dryva.Mobile.Aggregator.Test
{
    public class Tests
    {

        HttpClient client;
        string baseUrl;
        string controllerName = "Reports";

        [SetUp]
        public void Setup()
        {
            baseUrl = "http://localhost:60000/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        [Test, Order(6)]
        public async Task GetTestReport()
        {
            var requestUri = $"{controllerName}/customermap";
            var response = await client.GetAsync(requestUri);
            IEnumerable<Customer> result = null;
            IEnumerable<State> result_State = null;
            Combined res = null;

            if (response.IsSuccessStatusCode)
            {
               // result = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
                var pp = await response.Content.ReadAsAsync<Combined>();
               // result_State = await response.Content.ReadAsAsync<IEnumerable<State>>();
            }


            Assert.IsTrue(result != null);

            //IEnumerable<CustomerDetailDTO>
        }

        [Test, Order(6)]
        public async Task GetCustomerSubscriptionReport()
        {
            var requestUri = $"{controllerName}/customersubscription";
            var response = await client.GetAsync(requestUri);
            IEnumerable<CustomerSubscription> result = null;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<IEnumerable<CustomerSubscription>>();
            }
            Assert.IsTrue(result != null);
        }

    }

    public class CustomerSubscription
    {
        public string LGA { get; set; }
        public int NoofCustomers { get; set; }
        public int NoofSubscribers { get; set; }
    }
}