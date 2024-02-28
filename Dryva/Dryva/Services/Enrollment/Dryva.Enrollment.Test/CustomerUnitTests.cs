using Dryva.Enrollment.DTOs.Customer;
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
    public class CustomerUnitTests
    {
        CustomerDetailDTO customer;
        HttpClient client;
        Guid id = Guid.NewGuid();
        string baseUrl;
        string controllerName = "customers";

        [SetUp]
        public void Setup()
        {
            //string baseUrl = "http://d5d01ecf.ngrok.io/";
            string baseUrl = "http://localhost:60000";
            //baseUrl = "http://d5d01ecf.ngrok.io/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            customer = new CustomerDetailDTO
            {
                Title = "Mrs.",
                Surname = "Mary",
                FirstName = "Johnney",
                OtherName = null,
                Gender = "FeMale",
                Csn = 1234567890,
                PhoneNumber = "07030229161"
            };
        }

        [Test, Order(1)]
        public async Task Insert()
        {
            var response = await client.PostAsJsonAsync($"{controllerName}", customer);
            CustomerRegistrationDTO result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<CustomerRegistrationDTO>();

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
            customer.Id = id;
            customer.OtherName = "B.";
            customer.Address = "PH";
            customer.Email = "fg@gmail.com";

            var requestUri = $"{controllerName}/Contact/{id}";
            var response = await client.PutAsJsonAsync(requestUri, customer);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }

        [Test, Order(4)]
        public async Task UpdatePersonal()
        {
            var model = new CustomerPersonalDataDTO();
            model.Id = id;
            model.Country = "UK";
            model.BloodGroup = "O+";
            model.Genotype = "O";
            model.MaritalStatus = "Married";
            model.LGAOfOrigin = "Oyigbo";
            model.StateOfOrigin = "Rivers";


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
            customer.Id = id;
            customer.OtherName = "B.";

            var requestUri = $"{controllerName}/BioData/{id}";
            var response = await client.PutAsJsonAsync(requestUri, customer);
            object result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();

            Assert.IsTrue(result != null);
        }

        [Test, Order(5)]
        public async Task UpdateCSN()
        {
            customer.Id = id;
            customer.Csn = 1234;

            var requestUri = $"{controllerName}/CSN/{id}";
            var response = await client.PutAsJsonAsync(requestUri, customer);
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
            CustomerDataDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<CustomerDataDTO>();
            }
            Assert.IsTrue(result != null);
        }


        [Test, Order(7)]
        public async Task GetSpecifiedModelByPhoneNumer()
        {
            string phoneNumber = "07030229161";
            var requestUri = $"{controllerName}/CustomerByPhoneNumber/{phoneNumber}";
            var response = await client.GetAsync(requestUri);
            CustomerDataDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<CustomerDataDTO>();
            }
            Assert.IsTrue(result != null);
        }

        [Test, Order(7)]
        public async Task GetRegistrationByPhoneNumber()
        {
            var phoneNumber = "07030229161";
            var requestUri = $"{controllerName}/RegistrationByPhoneNumber/{phoneNumber}";
            var response = await client.GetAsync(requestUri);
            CustomerRegistrationDTO result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<CustomerRegistrationDTO>();
            }
            Assert.IsTrue(result != null);
        }

        //[Ignore("Don't Delete Model")]
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