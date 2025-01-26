using System.ComponentModel.DataAnnotations;

namespace Vehicle.Server.Controllers.Dto.Request
{
    public class PingRequest : IValidatableObject
    {
        public required string VehicleId { get; set; }
        public bool ConnectionStatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (VehicleId == null && string.IsNullOrEmpty(VehicleId))
            {
                validationResults.Add(new ValidationResult("vehicleId is required!"));
            }          

            return validationResults;
        }
    }
}
