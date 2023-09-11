using System;
using System.Collections.Generic;
using vehicle_solution.Models;

namespace vehicle_solution.Utility
{
    public static class DataGenerator
    {
        public static List<VehicleModel> GenerateRandomVehicleModels(int count)
        {
            var random = new Random();
            var vehicleModels = new List<VehicleModel>();

            var makeNames = new List<string> { "BMW", "Ford", "Volkswagen", "Toyota", "Honda" };
            var modelNames = new List<string> { "X5", "Focus", "Golf", "Camry", "Civic" };

            for (int i = 0; i < count; i++)
            {
                var make = makeNames[random.Next(makeNames.Count)];
                var model = modelNames[random.Next(modelNames.Count)];

                var randomVehicleModel = new VehicleModel
                {
                    Name = $"{make} {model}",
                    Abrv = $"{make[0]}{model[0]}",
                    Make = new VehicleMake
                    {
                        Name = make,
                        Abrv = $"{make[0]}"
                    }
                };

                vehicleModels.Add(randomVehicleModel);
            }

            return vehicleModels;
        }
    }
}
