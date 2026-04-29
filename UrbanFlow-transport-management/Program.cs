using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using UrbanFlow_transport_management.API.GrpcServices;
using UrbanFlow_transport_management.Application.Mapping;
using UrbanFlow_transport_management.Domain.Interfaces;
using UrbanFlow_transport_management.Infrastructure.Database;
using UrbanFlow_transport_management.Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddGrpc();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TransportManagementDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IRouteTypeRepository, RouteTypeRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddAutoMapper(
    cfg => {}, 
    typeof(RouteTypeMappingProfile)
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TransportManagementDbContext>();

        context.Database.EnsureCreated();

        Console.WriteLine("Database created OK");

    }
    catch (Exception ex)
    {
        Console.WriteLine("Database NOT OK : " + ex.Message);
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.MapScalarApiReference(options =>
    {
        options.Title = "UrbanFlow Transport Management API";
        options.Theme = ScalarTheme.Moon;
    });
}
app.MapGrpcService<VehicleService>();


app.UseAuthorization();
app.MapControllers();

app.Run();