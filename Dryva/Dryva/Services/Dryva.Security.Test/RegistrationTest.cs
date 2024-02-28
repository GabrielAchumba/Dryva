using Dryva.Security.DTOs;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dryva.Security.Test
{
    public class RegistrationTest
    {
        RegisterUserDTO registerUser;
        HttpClient client;
        string baseUrl;
        string controllerName = "Authorization";

        [SetUp]
        public void Setup()
        {
            baseUrl = "http://localhost:44308/";

            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // For authorization to make secure request to controllers with "AuthorizeAttribute"
            // pass the token gotten from LoginDTO<UserAccountDTO> here before making the request.

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Token");


            registerUser = new RegisterUserDTO
            {
                Email = "user@gmail.com",
                FirstName = "Demo",
                LastName = "User",
                Password = "@User100"
            };
        }

        [Test]
        public async Task Register()
        {
            var response = await client.PostAsJsonAsync($"api/{controllerName}/Register", registerUser);
            RegisterUserDTO result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<RegisterUserDTO>();

            Assert.IsTrue(result != null);
        }
    }
}