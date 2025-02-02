using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Repository.Models;

namespace Vehicle.Repository.Services
{
    public class VehicleStatusEntityTypeConfiguration : IEntityTypeConfiguration<VehicleStatus>
    {
        public void Configure(EntityTypeBuilder<VehicleStatus> builder)
        {
            builder
                .Property(b => b.Id)
                .IsRequired();

            builder
                .Property(b => b.VehicleId)
                .IsRequired()
                .HasMaxLength(100);            

            builder
                .Property(b => b.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasOne(m => m.Customer)
                .WithMany(a => a.VehicleStatuses)
                .HasForeignKey(m => m.CustomerId);

            builder
             .ToTable("VehicleStatuses");
        }
    }
}
