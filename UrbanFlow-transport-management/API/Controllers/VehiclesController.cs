using Microsoft.AspNetCore.Mvc;
using UrbanFlow_transport_management.Application.DTO.Vehicule;
using UrbanFlow_transport_management.Domain.Enum;
using UrbanFlow_transport_management.Domain.Interfaces;

namespace UrbanFlow_transport_management.API.Controllers;

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
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDto vehicle)
    {
        await repo.CreateVehicleAsync(vehicle);
        return Ok(new 
        {
            message = "Vehicle created"
        });
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        var status = repo.GetVehicleStatus();
        return Ok(status);
    }

    [HttpPut("{vehicleId}")]
    public IActionResult UpdateVehicle([FromBody] UpdateVehicleDto vehicle, int vehicleId)
    {
        repo.UpdateVehicle(vehicleId, vehicle);
        return Ok(new 
        {
            message = "Vehicle updated"
        });
    }
    
    [HttpPatch("status/{vehicleId}")]
    public IActionResult UpdateVehicleStatus([FromBody] VehicleStatus status, int vehicleId)
    {
        repo.UpdateVehicleStatus(vehicleId, status);
        return Ok(new 
        {
            message = "Vehicle status updated"
        });
    }

    [HttpDelete("{vehicleId}")]
    public IActionResult DeleteVehicle(int vehicleId)
    {
        repo.DeleteVehicle(vehicleId);
        return Ok(new
        {
            message = "Vehicle deleted"
        });
    }

    [HttpGet("vehicles/{agencyId}")]
    public IActionResult GetSeats(int agencyId)
    {
        var totalVehicles = repo.NumberOfVehiclesByAgencyId(agencyId);
        return Ok(totalVehicles);
    }
    
    
    
    
    
    
}