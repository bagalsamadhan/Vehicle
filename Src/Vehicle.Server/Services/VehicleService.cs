using Vehicle.Repository;
using Vehicle.Repository.Models;

namespace Vehicle.Server.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleStatus>> GetAllVehicleStatusAsync()
        {
            return await vehicleRepository.GetAllAsync();
        }

        public async Task<IEnumerable<VehicleStatus>> GetVehicleByCustomerAsync(int? customerId, string? customerName)
        {
            var data = customerId != null ? await vehicleRepository.GetByCustomerIdAsync((int)customerId) :
                await vehicleRepository.GetByCustomerNameAsync(customerName!);

            return data;
        }

        public async Task<bool> PingAsync(string vehicleId, bool connectionStatus)
        {
            return await vehicleRepository.PingAsync(vehicleId, connectionStatus);
        }
    }
}