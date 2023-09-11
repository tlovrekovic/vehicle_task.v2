using Microsoft.EntityFrameworkCore;
using vehicle_solution.Services;
using vehicle_solution.Services.VehicleService;
using vehicle_solution.Utility;
using vehicle_solution.Common.iService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<vehicle_solution.Data.DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//seeding DB
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<vehicle_solution.Data.DataContext>();
    var dataSeeder = new DataSeeder(context);
    //dataSeeder.SeedRandomVehicleModelsAsync(50).Wait(); 
}

app.Run();
