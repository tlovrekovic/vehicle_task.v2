using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicle_solution.Data;

namespace vehicle_solution.Utility
{
    public class DataSeeder
{
    private readonly DataContext _context;

    public DataSeeder(DataContext context)
    {
        _context = context;
    }

    //public async Task SeedRandomVehicleModelsAsync(int count)
    //{
       // var randomVehicleModels = DataGenerator.GenerateRandomVehicleModels(count);

       // await _context.AddRangeAsync(randomVehicleModels);
       // await _context.SaveChangesAsync();
  //  }
}
}