using AutoMapper;
using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using UrbanFlow_transport_management.Database;
using UrbanFlow_transport_management.DTO.RouteType;

namespace UrbanFlow_transport_management.Repository;

public class RouteTypeRepository(TransportManagementDbContext db, IMapper mapper)
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
    
    public async Task<List<GetRouteTypeDto>> GetAllRouteTypesByAgencyIdAsync()
    {
        var routeTypes = db.RouteTypes.Where(x =>  x.AgencyId == 1).AsNoTracking().ToList();
        return mapper.Map<List<GetRouteTypeDto>>(routeTypes);
    }

    public async Task DeleteRouteType(int id)
    {
        var agency = await GetRouteTypeById(id);
        
        if (agency == null)
            throw new KeyNotFoundException($"Agency with id {id} not found");
        
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