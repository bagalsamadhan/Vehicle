using AutoMapper;
using Vehicle.Server.Controllers.Dto.Responses;

namespace Vehicle.Server.Controllers.Dto
{
    public class DomainToDomainMapper : Profile
    {
        public DomainToDomainMapper()
        {
            CreateMap<Repository.Models.VehicleStatus, VehicleStatus>()
              .ConstructUsing(model => new VehicleStatus(model.Id, model.VehicleId, model.RegistrationNumber, model.ConnectionStatus, model.LastUpdatedDate));
        }
    }
}
