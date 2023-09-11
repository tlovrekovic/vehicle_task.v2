using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicle_solution.Common.DTOs
{
    public class UpdateVehicleMakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Volkswagen";
        public string Abrv { get; set; }= "VW";
    }
}