using Microsoft.AspNetCore.Mvc;
using UrbanFlow_transport_management.DTO.Vehicule;
using UrbanFlow_transport_management.Repository;

namespace UrbanFlow_transport_management.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController(IVehicleRepository repo) : Controller
{
    [HttpGet("filter/{id}")]
    public async Task<IActionResult> FilterRoutes([FromQuery] VehicleFilterDto filter, int id)
    {
        var vehicles = await repo.GetVehiclesByAgencyIdWithFilters(filter, id);
        if (!vehicles.Any()) return NotFound();
        return Ok(vehicles);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehiculeDto vehicle)
    {
        await repo.CreateVehicleAsync(vehicle);
        return Ok(new 
        {
            message = "Vehicle created"
        });
    }
}