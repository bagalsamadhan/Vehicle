using Microsoft.EntityFrameworkCore;
using Vehicle.Repository.Configurations;
using Vehicle.Repository.Models;

namespace Vehicle.Repository.Services
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<VehicleStatus> VehicleStatuses { get; set; }
        public virtual DbSet<VehicleStatusHistory> VehicleStatusHistories { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CustomerEntityTypeConfiguration().Configure(modelBuilder.Entity<Customer>());
            new VehicleStatusEntityTypeConfiguration().Configure(modelBuilder.Entity<VehicleStatus>());
            new VehicleStatusHistoryEntityTypeConfiguration().Configure(modelBuilder.Entity<VehicleStatusHistory>());
        }
    }
}
