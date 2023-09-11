using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using vehicle_solution.Common.DTOs;
using vehicle_solution.Models;

namespace vehicle_solution
{
    public class AutoMapperProfile : Profile
    {   public AutoMapperProfile()
    {
        CreateMap<VehicleMake,GetVehicleMakeDto>();
        CreateMap<AddVehicleMakeDto, VehicleMake>();

        CreateMap<VehicleModel,GetVehicleModelDto>();
        CreateMap<AddVehicleModelDto, VehicleModel>();
    }
    }
}