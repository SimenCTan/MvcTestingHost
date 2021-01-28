using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using WebApiHost;
using Xunit;

namespace IntegrationTest
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        /// <summary>
        /// init
        /// </summary>
        /// <param name="factory"></param>
        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/weatherforecast")]
        public async Task Test1(string url)
        {
            // Arrange
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });

            // act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}
