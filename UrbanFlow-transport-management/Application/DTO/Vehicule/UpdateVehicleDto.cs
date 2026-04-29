using UrbanFlow_transport_management.Domain.Enum;

namespace UrbanFlow_transport_management.DTO.Vehicule;

public class UpdateVehicleDto
{
    public required string RegistrationNumber { get; set; }
    public required int RouteTypeId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public required DateOnly ServiceDebut { get; set; }
    public int? SeatsCount { get; set; }
    public int? MaxCapacity { get; set; }
    public VehicleStatus Status { get; set; }
    public DateOnly? LastMaintenance { get; set; }
    public DateOnly? NextMaintenance => LastMaintenance?.AddMonths(6);
}