using DefaultNamespace;
using UrbanFlow_transport_management.Database;

namespace UrbanFlow_transport_management.Repository;

public class RouteTypeRepository(TransportManagementDbContext db)
{
    private async Task<RouteType?> GetRouteTypeById(int id)
    {
        return await db.RouteTypes.FindAsync(id);
    }
    
    
}