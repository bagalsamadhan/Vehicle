using System.ComponentModel.DataAnnotations;

namespace Vehicle.Repository.Models
{
    public class VehicleStatus
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual required Customer Customer { get; set; }
        [MaxLength(100)]
        public required string VehicleId { get; set; }
        [MaxLength(10)]
        public required string RegistrationNumber { get; set; }
        public bool ConnectionStatus { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
