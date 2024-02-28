using Nancy.Json;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dryva.Mobile.APIGateway.Aggregators
{
    public class CustomerSubscriptionAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            var xResponseContent = await responses.FirstOrDefault(r => r.DownstreamReRoute.Key.Equals("customer")).DownstreamResponse.Content.ReadAsStringAsync();

            var contentBuilder = new StringBuilder();
            contentBuilder.Append(xResponseContent);
            var oMycustomclassname = new JavaScriptSerializer().Deserialize<IEnumerable<Customer>>(xResponseContent);

            var cus = oMycustomclassname.GroupBy(x => x.LGAOfOrigin);
            Dictionary<Guid, CustomerSubscription> models = new Dictionary<Guid, CustomerSubscription>();
            List<string> subs = new List<string>() { "ef1b8cd1-3334-4786-be14-93cc9b4ccca9", "02138cd4-8ec1-4061-b5be-a5eb1f1da3a2" };
            List<CustomerSubscription> results = new List<CustomerSubscription>();
            foreach (var item in cus)
            {
                var cusSub = new CustomerSubscription() { LGA = item.Key, NoofCustomers = item.Count() };
                foreach (var pss in item)
                {
                    if (subs.Contains(pss.Id.ToString())){
                        cusSub.NoofSubscribers += 1;
                    }
                }
                results.Add(cusSub);
            }

            string contentBuilderText = new JavaScriptSerializer().Serialize(results);
            var stringContent = new StringContent(contentBuilderText)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
           // return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }

    }

    public class CustomerSubscription
    {
        public string LGA { get; set; }
        public int NoofCustomers { get; set; }
        public int NoofSubscribers { get; set; }
    }

    public class Customer
    {
        public Guid Id { get; set; }
        public string LGAOfOrigin { get; set; }
        public string StateOfOrigin { get; set; }
    }

}
