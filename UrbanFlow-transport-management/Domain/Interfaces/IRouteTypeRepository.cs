using UrbanFlow_transport_management.DTO.RouteType;

namespace UrbanFlow_transport_management.Repository;

public interface IRouteTypeRepository
{
    Task CreateRouteTypeAsync(CreateRouteTypeDto routeTypeDto);
    Task<List<GetRouteTypeDto>> GetAllRouteTypesByAgencyIdAsync(int id);
    //Task DeleteRouteType(int id);
    Task UpdateRouteTypeAsync(int id, UpdateRouteTypeDto routeTypeDto);
    Task<GetRouteTypeDto?> GetRouteTypeById(int id);
}