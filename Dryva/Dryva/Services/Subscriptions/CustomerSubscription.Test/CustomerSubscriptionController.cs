using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace CustomerSubscription.Test {
    public class CustomerSubscriptionController : TestClientProvider {
        
        string postData;

        public CustomerSubscriptionController() {
            postData = JsonConvert.SerializeObject(new {
                customerId = CustomerId,
                cardSerialNumber = CardSerialNumber,
                amount = 2500
            });
            
            Client.PostAsync("api/customers/subscribe", 
                new StringContent(postData, Encoding.UTF8, "application/json"));
        }
        
        [Fact]
        public async Task ReturnsCreatedAfterSubscribing() {
            postData = JsonConvert.SerializeObject(new {
                customerId = CustomerId,
                cardSerialNumber = CardSerialNumber,
                amount = 2500
            });
            
            var response = await Client.PostAsync("api/customers/subscribe", 
                new StringContent(postData, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task ReturnsOkAfterSubscriptionsAreRequestedUsingCardSerialNumber() {
            var response = await Client.GetAsync($"api/customers/{CardSerialNumber}/subscriptions");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ReturnsOkWhenTripDetailsAreRequestUsingForCustomerId() {
            var response = await Client.GetAsync($"api/customers/{CustomerId}/trips");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ReturnsOkAfterClocking() {
            var response = await Client.PutAsync($"api/customers/{CardSerialNumber}/in", null);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ReturnsOkWhenActiveSubscriptionIsRequested() {
            var response = await Client.GetAsync($"api/customers/{CardSerialNumber}/subscriptions/active");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ReturnsOkWhenTripsInfoIsRequested() {
            var response = await Client.GetAsync($"api/customers/{CustomerId}/trips");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}