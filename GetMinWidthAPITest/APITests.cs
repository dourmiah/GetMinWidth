using GetMinWidthAPI.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace GetMinWidthAPITest
{
    /// <summary>
    /// Test Minimal APIs
    /// </summary>
    public class APITests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public APITests(WebApplicationFactory<Program> factory) => _factory = factory;

        // Test the Minimal APIs
        [Fact]
        public async Task Test_Post_And_Get_Request()
        {
            var client = _factory.CreateClient();
            var order = new Order { Id = "Order1", products = { { "PhotoBook", 1 }, { "Mug", 2 } } };
            
            var post = await client.PostAsJsonAsync("/orders", order);
            Assert.True(post.IsSuccessStatusCode);

            var get = await client.GetAsync("/orders/Order1");
            Assert.True(get.IsSuccessStatusCode);
        }
    }
}
