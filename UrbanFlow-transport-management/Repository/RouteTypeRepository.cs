using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrbanFlow_transport_management.Database;
using UrbanFlow_transport_management.DTO.RouteType;
using UrbanFlow_transport_management.Models;

namespace UrbanFlow_transport_management.Repository;

public class RouteTypeRepository(TransportManagementDbContext db, IMapper mapper) : IRouteTypeRepository
{
    
    public async Task CreateRouteTypeAsync(CreateRouteTypeDto routeTypeDto)
    {
        ArgumentNullException.ThrowIfNull(routeTypeDto);

        var routeType = mapper.Map<RouteType>(routeTypeDto);
        await db.RouteTypes.AddAsync(routeType);
        await db.SaveChangesAsync();
    }
    
    
    private async Task<RouteType?> GetRouteTypeById(int id)
    {
        return await db.RouteTypes.FindAsync(id);
    }
    
    public async Task<List<GetRouteTypeDto>> GetAllRouteTypesByAgencyIdAsync(int id)
    {
        var routeTypes = await db.RouteTypes.Where(x =>  x.AgencyId == id).AsNoTracking().ToListAsync();
        return mapper.Map<List<GetRouteTypeDto>>(routeTypes);
    }

    public async Task DeleteRouteType(int id)
    {
        var agency = await GetRouteTypeById(id);
        
        if (agency == null)
            throw new KeyNotFoundException($"Routetype with id {id} not found");
        
        db.RouteTypes.Remove(agency);
        await db.SaveChangesAsync();
    }
    
    public async Task UpdateRouteTypeAsync(int id, UpdateRouteTypeDto routeTypeDto)
    {
        var routeType = await GetRouteTypeById(id);

        if (routeType == null)
            throw new KeyNotFoundException($"RouteType with id {id} not found");
        
        mapper.Map(routeTypeDto, routeType);
        
        await db.SaveChangesAsync();
    }
}