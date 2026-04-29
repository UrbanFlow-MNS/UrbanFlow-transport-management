using UrbanFlow_transport_management.DTO.Vehicule;
using UrbanFlow_transport_management.Models;

namespace UrbanFlow_transport_management.Repository;

public interface IVehicleRepository
{
    Task<List<Vehicule>> GetAllVehiclesByAgencyIdAsync(int agencyId);
    Task CreateVehicleAsync(CreateVehiculeDto vehiculeDto);
    int NumberOfVehiclesByAgencyId(int agencyId);
    Task? DeleteVehicle(int id);
    Task<List<GetVehiculeDto>> GetVehiclesByAgencyIdWithFilters(VehicleFilterDto filter, int id);
    public IEnumerable<VehicleStatusDto> GetVehicleStatus();

}