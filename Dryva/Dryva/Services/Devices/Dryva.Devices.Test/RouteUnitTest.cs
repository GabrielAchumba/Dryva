using Dryva.Devices.DTOs;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dryva.Devices.Test
{
    public class Tests
    {
        NewRouteDTO model;
        HttpClient client;
        Guid id = Guid.NewGuid();
        string baseUrl;
        string controllerName = "routes";

        [SetUp]
        public void Setup()
        {
            baseUrl = "http://localhost:60000/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            model = new NewRouteDTO
            {
                Source = "Ekot Epene2",
                Destination = "Ekot Epene3"
            };
        }

        [Test, Order(1)]
        public async Task Insert()
        {
            var response = await client.PostAsJsonAsync($"{controllerName}", model);
            RouteDTO result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<RouteDTO>();
            if (result != null)
                this.id = result.Id;

            Assert.IsTrue(result != null);
        }

        [Test, Order(2)]
        public async Task Update()
        {
            model.Destination = "Ekot Epene";

            var requestUri = $"{controllerName}/{id}";
            var response = await client.PutAsJsonAsync(requestUri, model);
            RouteDTO result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<RouteDTO>();

            Assert.IsTrue(result != null);
        }

        //[Ignore("Don't Delete Model")]
        [Test, Order(3)]
        public async Task Delete()
        {
            var requestUri = $"{controllerName}/{id}";
            var response = await client.DeleteAsync(requestUri);
            int result = 0;
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<int>();

            Assert.IsTrue(result == 1);
        }
    }
}