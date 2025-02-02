using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Repository.Models;

namespace Vehicle.Repository.Services
{
    public class VehicleStatusHistoryEntityTypeConfiguration : IEntityTypeConfiguration<VehicleStatusHistory>
    {
        public void Configure(EntityTypeBuilder<VehicleStatusHistory> builder)
        {
            builder
                .Property(b => b.Id)
                .IsRequired();

            builder
                .Property(b => b.VehicleId)
                .IsRequired()
                .HasMaxLength(100);

            builder
               .Property(b => b.CustomerId)
               .IsRequired();

            builder
                .Property(b => b.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasOne(m => m.Customer)
                .WithMany(a => a.VehicleStatusHistories)
                .HasForeignKey(m => m.CustomerId);

            builder
                .ToTable("VehicleStatusHistories");
        }
    }
}
