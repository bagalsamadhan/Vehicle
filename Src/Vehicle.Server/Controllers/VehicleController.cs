using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Server.Controllers.Dto.Request;
using Vehicle.Server.Controllers.Dto.Responses;
using Vehicle.Server.Services;

namespace Vehicle.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetVehicle")]
        public async Task<IEnumerable<VehicleStatus>> GetAsync()
        {
            var data = await vehicleService.GetAllVehicleStatusAsync();

            var VehicleStatusResponse = mapper.Map<IEnumerable<Repository.Models.VehicleStatus>, IEnumerable<VehicleStatus>>(data);

            return VehicleStatusResponse;
        }

        [HttpGet]
        [Route("Customer")]
        public async Task<IEnumerable<VehicleStatus>> GetVehiclesByCustomerAsync([FromQuery] CustomerRequest request, CancellationToken cancellationToken)
        {
            var data = await vehicleService.GetVehicleByCustomerAsync(request.CustomerId, request.CustomerName);

            var VehicleStatusResponse = mapper.Map<IEnumerable<Repository.Models.VehicleStatus>, IEnumerable<VehicleStatus>>(data);

            return VehicleStatusResponse;
        }

        [HttpPost]
        [Route("ping")]
        public async Task<IActionResult> PingVehicleAsync([FromBody] PingRequest request, CancellationToken cancellationToken)
        {
            var success = await vehicleService.PingAsync(request.VehicleId, request.ConnectionStatus);
            if (!success)
                return NotFound();

            return Ok();
        }
    }
}
