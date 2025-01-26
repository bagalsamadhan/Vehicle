namespace Vehicle.Server.Controllers.Dto.Responses
{
    public class VehicleStatus
    {
        public VehicleStatus(int id, string vehicleId, string registrationNumber, bool connectionStatus, DateTime lastUpdatedDate)
        {
            Id = id;
            VehicleId = vehicleId;
            RegistrationNumber = registrationNumber;
            ConnectionStatus = connectionStatus;
            LastUpdatedDate = lastUpdatedDate;
        }

        public int Id { get; set; }
        public string VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public bool ConnectionStatus { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}