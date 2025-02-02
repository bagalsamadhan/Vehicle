using Microsoft.EntityFrameworkCore;
using Vehicle.Repository.Models;

namespace Vehicle.Repository.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<VehicleStatus> VehicleStatuses { get; set; }
        public virtual DbSet<VehicleStatusHistory> VehicleStatusHistories { get; set; }
    }
}
