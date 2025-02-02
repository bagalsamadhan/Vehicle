namespace Vehicle.Repository.Models
{
    public class VehicleStatus
    {
        public int Id { get; set; }        
        public string VehicleId { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public bool ConnectionStatus { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public int CustomerId { get; set; }
        public virtual required Customer Customer { get; set; }
    }
}
