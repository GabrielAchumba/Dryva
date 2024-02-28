using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.DTOs.Lga;
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
    public class LGAUnitTests
    {
        HttpClient client;
        string baseUrl;
        string controllerName = "lgas";

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
            IEnumerable<LGADTO> result = new List<LGADTO>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<LGADTO>>();
            Assert.IsTrue(result.ToList().Count > 0);
        }


        [Test, Order(2)]
        public async Task GetSpecifiedModel()
        {
            var id = Guid.Parse("d5da69f6-e222-47b4-a7f7-206ed813cf99");
            var requestUri = $"{controllerName}/{id}";
            var response = await client.GetAsync(requestUri);
            LGADTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<LGADTO>();
            }
            Assert.IsTrue(result != null);
        }

        [Test, Order(3)]
        public async Task GetSpecifiedModelByState()
        {
            var stateId = Guid.Parse("707684ba-005b-48b0-a6fb-3000a7b88f82");
            var requestUri = $"{controllerName}/StateId/{stateId}";
            var response = await client.GetAsync(requestUri);
            IEnumerable<LGADTO> result = new List<LGADTO>();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<IEnumerable<LGADTO>>();
            }
            Assert.IsTrue(result.ToList().Count > 0);
        }


        [Test, Order(3)]
        public async Task GetSpecifiedModelByStateName()
        {
            var stateName = "Delta";
            var requestUri = $"{controllerName}/StateName/{stateName}";
            var response = await client.GetAsync(requestUri);
            IEnumerable<LGADTO> result = new List<LGADTO>();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<IEnumerable<LGADTO>>();
            }
            Assert.IsTrue(result.ToList().Count > 0);
        }
    }
}