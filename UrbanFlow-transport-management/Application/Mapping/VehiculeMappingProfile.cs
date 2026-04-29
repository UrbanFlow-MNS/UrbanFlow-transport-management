using AutoMapper;
using UrbanFlow_transport_management.DTO.RouteType;
using UrbanFlow_transport_management.DTO.Vehicule;
using UrbanFlow_transport_management.Models;

namespace UrbanFlow_transport_management.Mapping;

public class VehiculeMappingProfile : Profile
{
    public VehiculeMappingProfile()
    {
        CreateMap<CreateVehicleDto, Vehicule>();
        CreateMap<Vehicule, GetVehicleDto>();
        CreateMap<UpdateVehicleDto, Vehicule>();
    }
}