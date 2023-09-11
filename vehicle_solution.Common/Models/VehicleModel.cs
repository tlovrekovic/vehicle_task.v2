using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using vehicle_solution.Models;

namespace vehicle_solution.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; } = "Golf 7";
        public string Abrv { get; set; } = "G7";
        public  VehicleMake Make { get; set; } = new VehicleMake();
    }
}