using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vehicle_solution.Models;

namespace vehicle_solution.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<VehicleMake> VehicleMakes => Set<VehicleMake>();
        public DbSet<VehicleModel> VehicleModels => Set<VehicleModel>();

    }
}