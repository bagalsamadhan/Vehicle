namespace Vehicle.Repository.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public virtual ICollection<VehicleStatus>? VehicleStatuses { get; set; }
        public virtual ICollection<VehicleStatusHistory>? VehicleStatusHistories { get; set; }
    }
}
