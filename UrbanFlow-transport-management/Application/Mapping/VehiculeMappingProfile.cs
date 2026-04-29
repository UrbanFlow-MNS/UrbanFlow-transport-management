using AutoMapper;
using UrbanFlow_transport_management.Application.DTO.Vehicule;
using UrbanFlow_transport_management.Domain.Models;

namespace UrbanFlow_transport_management.Application.Mapping;

public class VehiculeMappingProfile : Profile
{
    public VehiculeMappingProfile()
    {
        CreateMap<CreateVehicleDto, Vehicule>();
        CreateMap<Vehicule, GetVehicleDto>();
        CreateMap<UpdateVehicleDto, Vehicule>();
    }
}