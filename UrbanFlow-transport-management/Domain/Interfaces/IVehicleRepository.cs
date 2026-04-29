using UrbanFlow_transport_management.Domain.Enum;
using UrbanFlow_transport_management.DTO.Vehicule;
using UrbanFlow_transport_management.Models;

namespace UrbanFlow_transport_management.Repository;

public interface IVehicleRepository
{
    Task CreateVehicleAsync(CreateVehicleDto vehicleDto);
    int NumberOfVehiclesByAgencyId(int agencyId);
    Task? DeleteVehicle(int id);
    Task<List<GetVehicleDto>> GetVehiclesByAgencyIdWithFilters(VehicleFilterDto filter, int id);
    public IEnumerable<VehicleStatusDto> GetVehicleStatus();
    Task UpdateVehicle(int id, UpdateVehicleDto vehicleDto);
    Task UpdateVehicleStatus(int id, VehicleStatus status);

}