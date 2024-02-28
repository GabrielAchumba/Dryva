using System.Net.Http;
using CustomerSubscription.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using CustomerSubscription.API.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CustomerSubscription.Test {
    public class TestClientProvider {
        protected TestClientProvider() {
            var server = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => {
                    builder.ConfigureServices(services => {
                        services.RemoveAll(typeof(SubscriptionDbContext));
                        services.AddDbContext<SubscriptionDbContext>(options => {
                            options.UseInMemoryDatabase("TestDb");
                        });
                    });
                });
            Client = server.CreateClient();
        }

        protected HttpClient Client { get; }

        protected string CustomerId { get; } = "693ACE8D-55E2-4168-ABD8-64DD264E2544";

        protected long CardSerialNumber { get; } = 552334109;
    }
}