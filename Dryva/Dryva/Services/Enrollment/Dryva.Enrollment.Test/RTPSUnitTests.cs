using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.DTOs.Investor;
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
    public class RTPSUnitTests
    {
        NewInvestorDTO investor;
        HttpClient client;
        Guid id = Guid.NewGuid();
        string baseUrl;
        string controllerName = "rtpss";

        [SetUp]
        public void Setup()
        {
            baseUrl = "http://localhost:60000/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            investor = new NewInvestorDTO
            {
                Title = "Mr.",
                Surname = "Kate",
                FirstName = "Aba",
                OtherName = null,
                Gender = "Male",
                Csn = 1234567890
            };
        }

        [Test, Order(1)]
        public async Task Insert()
        {
            var response = await client.PostAsJsonAsync($"{controllerName}", investor);
            InvestorDTO result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<InvestorDTO>();
            if (result != null)
                this.id = result.Id;

            Assert.IsTrue(result != null);
        }

        [Test, Order(2)]
        public async Task Update()
        {
            investor.OtherName = "B.";
            investor.FirstName = "FG";

            var requestUri = $"{controllerName}/{id}";
            var response = await client.PutAsJsonAsync(requestUri, investor);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }


        [Test, Order(6)]
        public async Task GetAll()
        {
            //var requestUri = $"maps/";
            var requestUri = $"{controllerName}?pageIndex=1&pageSize=10";
            var response = await client.GetAsync(requestUri);
            IEnumerable<CustomerDetailDTO> result = new List<CustomerDetailDTO>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<CustomerDetailDTO>>();
            Assert.IsTrue(result.ToList().Count > 0);
        }


        [Test, Order(7)]
        public async Task GetSpecifiedModel()
        {
            var requestUri = $"{controllerName}/{id}";
            var response = await client.GetAsync(requestUri);
            CustomerDetailDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<CustomerDetailDTO>();
            }
            Assert.IsTrue(result != null);
        }


        // [Ignore("Don't Delete Model")]
        [Test, Order(8)]
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