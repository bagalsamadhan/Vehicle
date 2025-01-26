using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;
using Vehicle.Repository.Models;
using Vehicle.Repository.Services;
using Vehicle.Repository.UnitTests.Helper;

namespace Vehicle.Repository.UnitTests
{
    public class VehicleRepositoryTest
    {
        [Fact]
        public void GetAll_VehicleStatus()
        {
            IQueryable<VehicleStatus> vehicleStatues = VehicleStatuses();

            var mockSet = new Mock<DbSet<VehicleStatus>>();
            mockSet.As<IQueryable<VehicleStatus>>().Setup(m => m.Provider).Returns(vehicleStatues.Provider);
            mockSet.As<IQueryable<VehicleStatus>>().Setup(m => m.Expression).Returns(vehicleStatues.Expression);
            mockSet.As<IQueryable<VehicleStatus>>().Setup(m => m.ElementType).Returns(vehicleStatues.ElementType);
            mockSet.As<IQueryable<VehicleStatus>>().Setup(m => m.GetEnumerator()).Returns(() => vehicleStatues.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.VehicleStatuses).Returns(mockSet.Object);

            var service = new VehicleRepository(mockContext.Object);
            var vehicleStatuses = service.GetAll();

            vehicleStatuses.Count().Should().Be(1);
            vehicleStatuses.Single().Id.Should().Be(1);
            vehicleStatuses.Single().VehicleId.Should().Be("YS2R4X20005399401");
            vehicleStatuses.Single().RegistrationNumber.Should().Be("ABC123");
            vehicleStatuses.Single().ConnectionStatus.Should().Be(false);
            vehicleStatuses.Single().CustomerId.Should().Be(1);

            vehicleStatuses.Single().Customer.CustomerId.Should().Be(1);
            vehicleStatuses.Single().Customer.Name.Should().Be("Kalles Grustransporter AB");
            vehicleStatuses.Single().Customer.Address.Should().Be("Cementvägen 8");
            vehicleStatuses.Single().Customer.PostalCode.Should().Be("111 11");
            vehicleStatuses.Single().Customer.City.Should().Be("Södertälje");
            vehicleStatuses.Single().Customer.Country.Should().Be("Sweden");
        }

        [Fact(Skip = "pending")]
        public async Task GetAllAsync_VehicleStatus()
        {
            IQueryable<VehicleStatus> vehicleStatues = VehicleStatuses();

            var mockSet = new Mock<DbSet<VehicleStatus>>();
            mockSet.As<IDbAsyncEnumerable<VehicleStatus>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<VehicleStatus>(vehicleStatues.GetEnumerator()));

            mockSet.As<IQueryable<VehicleStatus>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<VehicleStatus>(vehicleStatues.Provider));

            mockSet.As<IQueryable<VehicleStatus>>().Setup(m => m.Expression).Returns(vehicleStatues.Expression);
            mockSet.As<IQueryable<VehicleStatus>>().Setup(m => m.ElementType).Returns(vehicleStatues.ElementType);
            mockSet.As<IQueryable<VehicleStatus>>().Setup(m => m.GetEnumerator()).Returns(() => vehicleStatues.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.VehicleStatuses).Returns(mockSet.Object);

            var service = new VehicleRepository(mockContext.Object);
            var vehicleStatuses = await service.GetAllAsync();

            vehicleStatuses.Count().Should().Be(1);
        }

        private static IQueryable<VehicleStatus> VehicleStatuses()
        {
            return new List<VehicleStatus>
            {
                new VehicleStatus
                {
                    Id = 1,
                    CustomerId = 1,
                    Customer = new Customer
                    {
                        CustomerId = 1,
                        Name="Kalles Grustransporter AB",
                        Address="Cementvägen 8",
                        City="Södertälje",
                        PostalCode="111 11" ,
                        Country="Sweden"
                    },
                    ConnectionStatus = false,
                    RegistrationNumber = "ABC123",
                    VehicleId = "YS2R4X20005399401",
                    LastUpdatedDate = DateTime.Now
                }
            }.AsQueryable();
        }
    }
}