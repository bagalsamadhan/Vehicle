using System.ComponentModel.DataAnnotations;

namespace Vehicle.Repository.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public required string Address { get; set; }
        [MaxLength(7)]
        public required string PostalCode { get; set; }
        [MaxLength(30)]
        public required string City { get; set; }
        [MaxLength(30)]
        public required string Country { get; set; }
        [MaxLength(15)]
        public string? Phone { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public virtual ICollection<VehicleStatus>? VehicleStatuses { get; set; }
        public virtual ICollection<VehicleStatusHistory>? VehicleStatusHistories { get; set; }
    }
}
