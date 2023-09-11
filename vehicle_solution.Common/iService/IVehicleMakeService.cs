using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicle_solution.Common.DTOs;
using vehicle_solution.Parameters;
using vehicle_solution.Models;

namespace vehicle_solution.Common.iService
{
    public interface IVehicleMakeService
    {
         Task<ServiceResponse<List<GetVehicleMakeDto>>>GetAllVehicleMakes(PagingParameters pagingParameters, SortingParameters sortingParameters, FilteringParameters filteringParameters);
        Task<ServiceResponse<GetVehicleMakeDto>> GetVehicleMakeById(int id);
        Task<ServiceResponse<List<GetVehicleMakeDto>>> AddVehicleMake (AddVehicleMakeDto newVehicleMake);

        Task<ServiceResponse<GetVehicleMakeDto>> UpdateVehicleMake (UpdateVehicleMakeDto updatedVehicleMake);

        Task<ServiceResponse<List<GetVehicleMakeDto>>>DeleteVehicleMake(int id);
    }
}