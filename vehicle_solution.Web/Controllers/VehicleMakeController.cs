using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vehicle_solution.Common.DTOs;
using vehicle_solution.Models;
using vehicle_solution.Parameters;
using vehicle_solution.Common.iService;


namespace vehicle_solution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleMakeController : ControllerBase
    {

        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetVehicleMakeDto>>>> Get(
    [FromQuery] PagingParameters pagingParameters,
    [FromQuery] SortingParameters sortingParameters,
    [FromQuery] FilteringParameters filteringParameters)
        {
            return Ok(await _vehicleMakeService.GetAllVehicleMakes(pagingParameters, sortingParameters, filteringParameters));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetVehicleMakeDto>>> GetSingle(int id)
        {
            return Ok(await _vehicleMakeService.GetVehicleMakeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetVehicleMakeDto>>> AddVehicleMake(AddVehicleMakeDto newVehicleMake)
        {

            return Ok(await _vehicleMakeService.AddVehicleMake(newVehicleMake));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetVehicleMakeDto>>> UpdateVehicleMake(UpdateVehicleMakeDto updatedVehicleMake)
        {
            var response = await _vehicleMakeService.UpdateVehicleMake(updatedVehicleMake);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetVehicleMakeDto>>> DeleteVehicleMake(int id)
        {
            var response = await _vehicleMakeService.DeleteVehicleMake(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok();
        }
    }
}