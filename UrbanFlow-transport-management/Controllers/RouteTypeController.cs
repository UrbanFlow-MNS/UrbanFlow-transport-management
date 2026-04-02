using Microsoft.AspNetCore.Mvc;
using UrbanFlow_transport_management.DTO.RouteType;
using UrbanFlow_transport_management.Models;
using UrbanFlow_transport_management.Repository;

namespace UrbanFlow_transport_management.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RouteTypeController(IRouteTypeRepository repo) : Controller
{

    [HttpGet("/{agencyid}")]
    public async Task<List<GetRouteTypeDto>> GetRouteTypeByAgencyId(int id)
    {
        return await repo.GetAllRouteTypesByAgencyIdAsync(id);
    }

    [HttpPost("create")]
    public async Task CreateRouteTypeAsync(CreateRouteTypeDto dto)
    {
        await repo.CreateRouteTypeAsync(dto);
    }

    
}