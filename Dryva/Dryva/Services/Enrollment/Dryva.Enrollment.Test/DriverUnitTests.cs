using Dryva.Enrollment.DTOs.Driver;
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
    public class DriverUnitTests
    {
        DriverDetailDTO customer;
        HttpClient client;
        Guid id = Guid.NewGuid();
        string baseUrl;
        string controllerName = "drivers";

        [SetUp]
        public void Setup()
        {
            baseUrl = "http://localhost:60000/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            customer = new DriverDetailDTO
            {
                Title = "Mr.",
                Surname = "Paul",
                FirstName = "Ese",
                OtherName = null,
                Gender = "Male",
                Csn = 1234567890,
                PhoneNumber = "08037502316"
            };
        }

        [Test, Order(1)]
        public async Task Insert()
        {
            var response = await client.PostAsJsonAsync($"{controllerName}", customer);
            DriverRegistrationDTO result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<DriverRegistrationDTO>();
           
            if (result != null)
            {
                this.id = result.Id;
            }
            Assert.IsTrue(result != null);
        }

        [Test, Order(2)]
        public async Task UpdateRegistration()
        {
            customer.Id = id;
            customer.OtherName = "B.";
            customer.PhoneNumber = "1234567890";
            var requestUri = $"{controllerName}/Registration/{id}";
            var response = await client.PutAsJsonAsync(requestUri, customer);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }


        [Test, Order(3)]
        public async Task UpdateContact()
        {
            var model = new DriverContactDTO();
            model.Id = id;
            model.Address = "111 location road, PH";
            model.Address = "PH";
            model.Email = "fg@gmail.com";

            var requestUri = $"{controllerName}/Contact/{id}";
            var response = await client.PutAsJsonAsync(requestUri, model);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }

        [Test, Order(4)]
        public async Task UpdatePersonal()
        {
            var model = new DriverPersonalDataDTO();
            model.Id = id;
            model.Country = "USA";
            model.BloodGroup = "O+";
            model.Genotype = "O";
            model.MaritalStatus = "Single";

            var requestUri = $"{controllerName}/PersonalData/{id}";
            var response = await client.PutAsJsonAsync(requestUri, model);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }

        [Test, Order(5)]
        public async Task UpdateBioData()
        {
            var model = new DriverBioDataDTO();
            model.Id = id;
            
            var requestUri = $"{controllerName}/BioData/{id}";
            var response = await client.PutAsJsonAsync(requestUri, model);
            object result=null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }

        [Test, Order(6)]
        public async Task UpdateOwnerNOKData()
        {
            var model = new DriverOwnerNOKDTO();
            model.Id = id;
            model.OwnerAddress = "111 location road, PH";
            model.IsOwner = true;

            var requestUri = $"{controllerName}/OwnerNOKData/{id}";
            var response = await client.PutAsJsonAsync(requestUri, model);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }

        [Test, Order(7)]
        public async Task UpdateVehicleData()
        {
            var model = new DriverVehicleDTO();
            model.Id = id;
            model.ChassisNumber = "11197h9sc";
            model.MakeAndModel = "Toyota";

            var requestUri = $"{controllerName}/VehicleData/{id}";
            var response = await client.PutAsJsonAsync(requestUri, model);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }


        [Test, Order(8)]
        public async Task GetAll()
        {
            //var requestUri = $"maps/";
            var requestUri = $"{controllerName}?pageIndex=1&pageSize=10";
            var response = await client.GetAsync(requestUri);
            IEnumerable<DriverDetailDTO> result = new List<DriverDetailDTO>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<DriverDetailDTO>>();
            Assert.IsTrue(result.ToList().Count > 0);
        }


        [Test, Order(9)]
        public async Task GetSpecifiedModel()
        {
            var requestUri = $"{controllerName}/{id}";
            var response = await client.GetAsync(requestUri);
            DriverDataDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<DriverDataDTO>();
            }
            Assert.IsTrue(result != null);
        }


       // [Ignore("Don't Delete Model")]
        [Test, Order(10)]
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