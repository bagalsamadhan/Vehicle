using FluentAssertions;
using Moq;
using Vehicle.Repository;
using Vehicle.Repository.Models;
using Vehicle.Server.Services;

namespace Vehicle.Server.UnitTests
{
    public class VehicleServiceTest
    {
        private readonly Mock<IVehicleRepository> mockVehicleRepostiory;
        private readonly IVehicleService vehicleService;

        public VehicleServiceTest()
        {
            mockVehicleRepostiory = new Mock<IVehicleRepository>();
            vehicleService = new VehicleService(mockVehicleRepostiory.Object);
        }

        [Fact]
        public async Task GivenVehicleStatus_WhenCallingGetAllVehicleStatusAsync_ThenReturnsRsult()
        {
            // Arrange
            IEnumerable<VehicleStatus> vehicleStatuses = VehicleStatusData();
            mockVehicleRepostiory.Setup(sd => sd.GetAllAsync()).ReturnsAsync(vehicleStatuses);

            // Act
            var result = await vehicleService.GetAllVehicleStatusAsync();

            // Assert
            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task GivenCustomerId_WhenCallingGetByCustomerIdAsync_ThenReturnsRsult()
        {
            // Arrange
            IEnumerable<Repository.Models.VehicleStatus> vehicleStatuses = VehicleStatusData();

            mockVehicleRepostiory.Setup(sd => sd.GetByCustomerIdAsync(It.IsAny<int>())).ReturnsAsync(vehicleStatuses);

            // Act
            var result = await vehicleService.GetVehicleByCustomerAsync(1, string.Empty);

            // Assert
            result.Should().HaveCount(1);
        }

        private static IEnumerable<VehicleStatus> VehicleStatusData()
        {
            return [
                new Repository.Models.VehicleStatus
                {
                    Id = 1,
                    CustomerId = 1,
                    Customer = new Repository.Models.Customer
                    {
                        CustomerId = 1,
                        Name="Kalles Grustransporter AB",
                        Address="Cementvägen 8",
                        City="Södertälje",   PostalCode="111 11" ,
                        Country="Sweden"
                    },
                    ConnectionStatus = false,
                    RegistrationNumber = "ABC123",
                    VehicleId = "YS2R4X20005399401",
                    LastUpdatedDate = DateTime.Now
                }
                ];
        }
    }
}