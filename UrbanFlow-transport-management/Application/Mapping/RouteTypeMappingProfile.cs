using AutoMapper;
using UrbanFlow_transport_management.Application.DTO.RouteType;
using UrbanFlow_transport_management.Domain.Models;

namespace UrbanFlow_transport_management.Application.Mapping;

public class RouteTypeMappingProfile : Profile
{
    public RouteTypeMappingProfile()
    {
        CreateMap<RouteType, GetRouteTypeDto>();
        CreateMap<CreateRouteTypeDto, RouteType>();
        CreateMap<UpdateRouteTypeDto, RouteType>();
    }
}