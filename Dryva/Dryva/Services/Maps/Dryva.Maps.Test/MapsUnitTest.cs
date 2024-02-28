using Dryva.Maps.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dryva.Maps.Test
{
    public class MapsUnitTest
    {
        NewMapAxisDTO model;
        HttpClient client;
        Guid id = Guid.NewGuid();
        string baseUrl;
        string controllerName = "maps";

        [SetUp]
        public void Setup()
        {
            baseUrl = "http://localhost:60000/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            model = new NewMapAxisDTO
            {
                Code = "23",
                Description = "Testing Map",
                Latitude = 201,
                Longitude = 305,
                Zoom = 3,
                Name = "Dryva vehicle 1",
                ParentCode = "23"
            };
        }


        [Test, Order(1)]
        public async Task InsertMap()
        {
            var response = await client.PostAsJsonAsync($"{controllerName}", model);
            MapAxisDTO result = null ;
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<MapAxisDTO>();
            if (result != null)
                this.id = result.Id;
            
            Assert.IsTrue(result !=null);
        }

        [Test, Order(2)]
        public async Task UpdateMap()
        {
            model.Description = "NUnit testing ongoing...";

            var requestUri = $"{controllerName}/{id}";
            var response = await client.PutAsJsonAsync(requestUri, model);
            MapAxisDTO result = null;
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<MapAxisDTO>();
            Assert.IsTrue(result != null);
        }

        [Test, Order(3)]
        public async Task GetAllMap()
        {
            //var requestUri = $"maps/";
            var requestUri = $"{controllerName}?pageIndex=1&pageSize=10";
            var response = await client.GetAsync(requestUri);
            IEnumerable<MapAxisDTO> result = new List<MapAxisDTO>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<MapAxisDTO>>();
            Assert.IsTrue(result.ToList().Count > 0);
        }

        [Test, Order(4)]
        public async Task GetSpecifiedMap()
        {
            var requestUri = $"{controllerName}/{id}";
            var response = await client.GetAsync(requestUri);
            MapAxisDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<MapAxisDTO>();
            }
            Assert.IsTrue(result != null);
        }

        [Test, Order(4)]
        public async Task GetClosestMapAxisByLocation()
        {
            float lon = 340;
            float lat = 210;

            var requestUri = $"{controllerName}/ClosestMapAxisByLocation/{lon}/{lat}";
            var response = await client.GetAsync(requestUri);
            MapAxisDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<MapAxisDTO>();
            }
            Assert.IsTrue(result != null);
        }

        //[Ignore("Don't Delete Model")]
        [Test, Order(6)]
        public async Task DeleteMap()
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