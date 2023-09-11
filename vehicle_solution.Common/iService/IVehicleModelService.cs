using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicle_solution.Common.DTOs;
using vehicle_solution.Parameters;
using vehicle_solution.Models;

namespace vehicle_solution.Common.iService
{
    public interface IVehicleModelService
    {
         Task<ServiceResponse<List<GetVehicleModelDto>>>GetAllVehicleModels(PagingParameters pagingParameters, SortingParameters sortingParameters, FilteringParameters filteringParameters);
        Task<ServiceResponse<GetVehicleModelDto>> GetVehicleModelById(int id);
        Task<ServiceResponse<List<GetVehicleModelDto>>> AddVehicleModel (AddVehicleModelDto newVehicleModel);

        Task<ServiceResponse<GetVehicleModelDto>> UpdateVehicleModel (UpdateVehicleModelDto updatedVehicleModel);

        Task<ServiceResponse<List<GetVehicleModelDto>>>DeleteVehicleModel(int id);
    }
}