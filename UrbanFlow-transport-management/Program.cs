using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using UrbanFlow_transport_management.Database;
using UrbanFlow_transport_management.Mapping;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TransportManagementDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(
    cfg => {}, 
    typeof(RouteTypeMappingProfile)
);
//builder.Services.AddOpenApi();

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
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();