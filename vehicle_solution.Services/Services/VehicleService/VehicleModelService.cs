using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vehicle_solution.Data;
using vehicle_solution.Common.DTOs;
using vehicle_solution.Parameters;
using vehicle_solution.Models;
using vehicle_solution.Common.iService;

namespace vehicle_solution.Services.VehicleService
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VehicleModelService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetVehicleModelDto>>> AddVehicleModel(AddVehicleModelDto newVehicleModel)
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleModelDto>>();
            try
            {
                var vehicleModel = _mapper.Map<VehicleModel>(newVehicleModel);
                _context.VehicleModels.Add(vehicleModel);
                vehicleModel = await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == vehicleModel.Id);
                serviceResponse.Data = new List<GetVehicleModelDto> { _mapper.Map<GetVehicleModelDto>(vehicleModel) };
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to add vehicle model: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVehicleModelDto>>> DeleteVehicleModel(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleModelDto>>();
            try
            {

                var vehicleModel = await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == id);
                if (vehicleModel is null)
                    throw new Exception($"Vehicle model with Id '{id}' not found.");

                _context.VehicleModels.Remove(vehicleModel);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.VehicleModels
            .Select(c => _mapper.Map<GetVehicleModelDto>(c))
            .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVehicleModelDto>>> GetAllVehicleModels(PagingParameters pagingParameters, SortingParameters sortingParameters, FilteringParameters filteringParameters)
        {
            var serviceResponse = new ServiceResponse<List<GetVehicleModelDto>>();
             try
            {
                var query = _context.VehicleModels.AsQueryable();
                if (!string.IsNullOrEmpty(filteringParameters.Keyword))
                {
                    var searchTerm = filteringParameters.Keyword.Trim().ToLower();
                    query = query.Where(vm => vm.Name.ToLower().Contains(searchTerm) || vm.Abrv.ToLower().Contains(searchTerm));
                }

                if (!string.IsNullOrEmpty(sortingParameters.SortBy))
                {
                    switch (sortingParameters.SortBy.ToLower())
                    {
                        case "name":
                            query = sortingParameters.SortDirection == "asc" ? query.OrderBy(vm => vm.Name) : query.OrderByDescending(vm => vm.Name);
                            break;
                        case "id":
                            query = sortingParameters.SortDirection == "asc" ? query.OrderBy(vm => vm.Id) : query.OrderByDescending(vm => vm.Id);
                            break;
                        case "abrv":
                            query = sortingParameters.SortDirection == "asc" ? query.OrderBy(vm => vm.Abrv) : query.OrderByDescending(vm => vm.Abrv);
                            break;
                        default:
                            break;
                    }
                }
                //straničenje
                int skip = (pagingParameters.PageNumber - 1) * pagingParameters.PageSize;
                int take = pagingParameters.PageSize;
                query = query.Skip(skip).Take(take);
                var dbCharacters = await query.ToListAsync();
                serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetVehicleModelDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to retrieve vehicle makes: " + ex.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVehicleModelDto>> GetVehicleModelById(int id)
        {
            var serviceResponse = new ServiceResponse<GetVehicleModelDto>();
            var dbCharacter = await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetVehicleModelDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVehicleModelDto>> UpdateVehicleModel(UpdateVehicleModelDto updatedVehicleModel)
        {
             var serviceResponse = new ServiceResponse<GetVehicleModelDto>();

            try
            {
                var vehicleModel = await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == updatedVehicleModel.Id);

                if (vehicleModel is null)
                    throw new Exception($"Vehicle make with Id '{updatedVehicleModel.Id}' not found.");
                vehicleModel.Name = updatedVehicleModel.Name;
                vehicleModel.Abrv = updatedVehicleModel.Abrv;
                vehicleModel.Make = updatedVehicleModel.Make;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetVehicleModelDto>(updatedVehicleModel);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }


    }
}