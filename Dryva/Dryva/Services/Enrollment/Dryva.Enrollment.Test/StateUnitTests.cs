
using Dryva.Enrollment.DTOs.State;
using Dryva.Enrollment.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Test
{
    public class StateUnitTests
    {
        HttpClient client;
        string baseUrl;
        string controllerName = "states";

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


        [Test, Order(1)]
        public async Task GetAll()
        {
            //var requestUri = $"maps/";
            var requestUri = $"{controllerName}?pageIndex=1&pageSize=10";
            var response = await client.GetAsync(requestUri);
            IEnumerable<StateDTO> result = new List<StateDTO>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<StateDTO>>();
            Assert.IsTrue(result.ToList().Count > 0);
        }


        [Test, Order(2)]
        public async Task GetSpecifiedModel()
        {
            var id = Guid.Parse("707684ba-005b-48b0-a6fb-3000a7b88f82");
            var requestUri = $"{controllerName}/{id}";
            var response = await client.GetAsync(requestUri);
            StateDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<StateDTO>();
            }
            Assert.IsTrue(result != null);
        }


    }
}