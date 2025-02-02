using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Repository.Models;

namespace Vehicle.Repository.Configurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(b => b.CustomerId)
                .IsRequired();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.PostalCode)
                .IsRequired()
                .HasMaxLength(7);

            builder
                .Property(m => m.City)
                .IsRequired()
                .HasMaxLength(30);

            builder.
                Property(m => m.Country)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(m => m.Phone)
                .HasMaxLength(15);

            builder
              .ToTable("Customers");
        }
    }
}
