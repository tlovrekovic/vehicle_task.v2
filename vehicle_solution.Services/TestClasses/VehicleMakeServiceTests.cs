using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using vehicle_solution;
using vehicle_solution.Data;
using vehicle_solution.Common.DTOs;
using vehicle_solution.Models;
using vehicle_solution.Services.VehicleService;
namespace YourNamespace.Tests
{
    [TestClass]
    public class VehicleMakeServiceTests
    {
        private IMapper _mapper;
        private DbContextOptions<DataContext> _options;

        [TestInitialize]
        public void Initialize()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = configuration.CreateMapper();

            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;
        }

        [TestMethod]
        public async Task AddVehicleMake_ValidInput_ShouldAdd()
        {
            // Arrange
            using (var context = new DataContext(_options))
            {
                var service = new VehicleMakeService(_mapper, context);
                var newMakeDto = new AddVehicleMakeDto { Name = "Toyota", Abrv = "T" };

                // Act
                var result = await service.AddVehicleMake(newMakeDto);

                // Assert
                Assert.IsTrue(result.Success);
                Assert.AreEqual("Toyota", result.Data[0].Name);
            }
        }

        [TestMethod]
        public async Task DeleteVehicleMake_ExistingMake_ShouldDelete()
        {
            // Arrange
            using (var context = new DataContext(_options))
            {
                var make = new VehicleMake { Name = "Honda", Abrv = "H" };
                context.VehicleMakes.Add(make);
                context.SaveChanges();

                var service = new VehicleMakeService(_mapper, context);

                // Act
                var result = await service.DeleteVehicleMake(make.Id);

                // Assert
                Assert.IsTrue(result.Success);
                Assert.AreEqual(0, context.VehicleMakes.Count());
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            // Dispose of the in-memory database context
            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
