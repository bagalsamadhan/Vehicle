using System.ComponentModel.DataAnnotations;

namespace Vehicle.Server.Controllers.Dto.Request
{
    public class CustomerRequest : IValidatableObject
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (CustomerId == null && string.IsNullOrEmpty(CustomerName))
            {
                validationResults.Add(new ValidationResult("customerId and customerName are empty!"));
            }

            if (CustomerId == null && string.IsNullOrEmpty(CustomerName))
            {
                validationResults.Add(new ValidationResult("Both customerId and customerName should not have values!"));
            }

            return validationResults;
        }
    }
}
