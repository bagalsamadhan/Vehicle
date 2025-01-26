using Vehicle.Repository.Models;

namespace Vehicle.Server.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleStatus>> GetAllVehicleStatusAsync();
        Task<IEnumerable<VehicleStatus>> GetVehicleByCustomerAsync(int? customerId, string? customerName);
        Task<bool> PingAsync(string vehicleId, bool connectionStatus);
    }
}