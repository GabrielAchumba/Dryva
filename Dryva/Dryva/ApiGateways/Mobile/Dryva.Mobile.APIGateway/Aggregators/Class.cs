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

namespace Dryva.Mobile.APIGateway
{
    public class CustomerAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate2(List<DownstreamContext> responses)
        {
            var dst = new DownstreamResponse(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
            return new Task<DownstreamResponse>(() =>
            {
                return dst;
            });

            //var dst = new DownstreamResponse(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
            //return new Task(() =>
            //{
            //    return dst;
            //});
        }

        public async Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            var xResponseContent = await responses.FirstOrDefault(r => r.DownstreamReRoute.Key.Equals("cus")).DownstreamResponse.Content.ReadAsStringAsync();

            var yResponseContent = await responses.FirstOrDefault(r => r.DownstreamReRoute.Key.Equals("state")).DownstreamResponse.Content.ReadAsStringAsync();

            var contentBuilder = new StringBuilder();
            contentBuilder.Append(xResponseContent);
            contentBuilder.Append(yResponseContent);

            var stringContent = new StringContent(contentBuilder.ToString())
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }

}