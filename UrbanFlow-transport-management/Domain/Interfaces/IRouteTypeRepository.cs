using UrbanFlow_transport_management.Application.DTO.RouteType;

namespace UrbanFlow_transport_management.Domain.Interfaces;

public interface IRouteTypeRepository
{
    Task CreateRouteTypeAsync(CreateRouteTypeDto routeTypeDto);
    Task<List<GetRouteTypeDto>> GetAllRouteTypesByAgencyIdAsync(int id);
    //Task DeleteRouteType(int id);
    Task UpdateRouteTypeAsync(int id, UpdateRouteTypeDto routeTypeDto);
    Task<GetRouteTypeDto?> GetRouteTypeById(int id);
}