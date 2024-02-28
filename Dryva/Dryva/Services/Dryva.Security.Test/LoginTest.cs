using Dryva.Security.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dryva.Security.Test
{
    public class LoginTest
    {
        CredentialDTO credential;
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

            credential = new CredentialDTO
            {
                Email = "user@gmail.com",
                Password = "@User100"
            };
        }

        [Test]
        public async Task Login()
        {
            var response = await client.PostAsJsonAsync($"api/{controllerName}/LoginUser", credential);
            LoginDTO<UserAccountDTO> result = null;

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<LoginDTO<UserAccountDTO>>();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Authenticated);
            Assert.IsTrue(result.Token != null);
        }

    }
}
