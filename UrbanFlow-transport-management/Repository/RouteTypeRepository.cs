using AutoMapper;
using DefaultNamespace;
using UrbanFlow_transport_management.Database;
using UrbanFlow_transport_management.DTO.RouteType;

namespace UrbanFlow_transport_management.Repository;

public class RouteTypeRepository(TransportManagementDbContext db, IMapper mapper)
{
    
    public async Task CreateAgencyAsync(CreateRouteTypeDTO routeTypeDto)
    {
        ArgumentNullException.ThrowIfNull(routeTypeDto);

        var agency = mapper.Map<RouteType>(routeTypeDto);
        await db.RouteTypes.AddAsync(agency);
        await db.SaveChangesAsync();
    }
    
    
    private async Task<RouteType?> GetRouteTypeById(int id)
    {
        return await db.RouteTypes.FindAsync(id);
    }
    
    
}