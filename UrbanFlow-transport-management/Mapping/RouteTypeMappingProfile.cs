using AutoMapper;
using DefaultNamespace;
using UrbanFlow_transport_management.DTO.RouteType;

namespace UrbanFlow_transport_management.Mapping;

public class RouteTypeMappingProfile : Profile
{
    public RouteTypeMappingProfile()
    {
        CreateMap<RouteType, GetRouteTypeDTO>();
        CreateMap<CreateRouteTypeDTO, RouteType>();
        CreateMap<UpdateRouteTypeDTO, RouteType>();
    }
}