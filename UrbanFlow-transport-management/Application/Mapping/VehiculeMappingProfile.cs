using AutoMapper;
using UrbanFlow_transport_management.DTO.RouteType;
using UrbanFlow_transport_management.DTO.Vehicule;
using UrbanFlow_transport_management.Models;

namespace UrbanFlow_transport_management.Mapping;

public class VehiculeMappingProfile : Profile
{
    public VehiculeMappingProfile()
    {
        CreateMap<CreateVehiculeDto, Vehicule>();
        CreateMap<Vehicule, GetVehiculeDto>();
    }
}