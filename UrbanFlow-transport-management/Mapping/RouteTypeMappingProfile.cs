using AutoMapper;
using UrbanFlow_transport_management.DTO.RouteType;
using UrbanFlow_transport_management.Models;

namespace UrbanFlow_transport_management.Mapping;

public class RouteTypeMappingProfile : Profile
{
    public RouteTypeMappingProfile()
    {
        CreateMap<RouteType, GetRouteTypeDto>();
        CreateMap<CreateRouteTypeDto, RouteType>();
        CreateMap<UpdateRouteTypeDto, RouteType>();
    }
}