using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Vehicle.Server.IntegrationTests
{
    public class VehicleControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private const string RootPath = "/Vehicle";

        public VehicleControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAsync_Should_Return_OK_When_The_Result_Success()
        {
            // Arrange
            var client = _factory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, RootPath);

            // Act
            var response = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);

            // Assert
            response.Should().BeOfType<HttpResponseMessage>().Which.StatusCode.Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetVehiclesByCustomerAsync_Should_Return_OK_When_The_Result_Success()
        {
            // Arrange
            var client = _factory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, RootPath + "/customer?customerId=1");

            // Act
            var response = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);

            // Assert
            response.Should().BeOfType<HttpResponseMessage>().Which.StatusCode.Should()
                .Be(HttpStatusCode.OK);
        }
    }
}