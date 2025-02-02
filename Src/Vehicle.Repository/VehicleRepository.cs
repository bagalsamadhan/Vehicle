using Microsoft.EntityFrameworkCore;
using Vehicle.Repository.Services;

namespace Vehicle.Repository
{
    public interface IVehicleRepository
    {
        IEnumerable<Models.VehicleStatus> GetAll();
        Task<IEnumerable<Models.VehicleStatus>> GetAllAsync();
        Task<IEnumerable<Models.VehicleStatus>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<Models.VehicleStatus>> GetByCustomerNameAsync(string customerName);

        Task<bool> PingAsync(string vehicleId, bool connectionStatus);
    }

    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext context;
        public VehicleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Models.VehicleStatus> GetAll()
        {
            return [.. this.context.VehicleStatuses];
        }

        public async Task<IEnumerable<Models.VehicleStatus>> GetAllAsync()
        {
            return await this.context.VehicleStatuses.ToListAsync();
        }

        public async Task<IEnumerable<Models.VehicleStatus>> GetByCustomerIdAsync(int customerId)
        {
            return await context.VehicleStatuses.Where(s => s.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Models.VehicleStatus>> GetByCustomerNameAsync(string customerName)
        {
            return await context.VehicleStatuses.Where(s => s.Customer.Name == customerName).ToListAsync();
        }

        public async Task<bool> PingAsync(string vehicleId, bool connectionStatus)
        {
            var vehicleStatus = await context.VehicleStatuses.FirstOrDefaultAsync(s => s.VehicleId == vehicleId);

            if (vehicleStatus == null)
                return false;

            vehicleStatus.ConnectionStatus = connectionStatus;
            context.VehicleStatuses.Update(vehicleStatus);

            context.VehicleStatusHistories.Add(new Models.VehicleStatusHistory
            {
                ConnectionStatus = vehicleStatus.ConnectionStatus,
                VehicleId = vehicleStatus.VehicleId,
                CustomerId = vehicleStatus.CustomerId,
                LastUpdatedDate = DateTime.UtcNow,
                RegistrationNumber = vehicleStatus.RegistrationNumber,
                Customer = vehicleStatus.Customer
            });

            await context.SaveChangesAsync();
            return true;
        }
    }
}
