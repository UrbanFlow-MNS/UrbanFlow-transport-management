using UrbanFlow_transport_management.Domain.Enum;

namespace UrbanFlow_transport_management.Application.DTO.Vehicule;

public class VehicleFilterDto
{
    public string? RegistrationNumber { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public VehicleStatus? Status { get; set; }
    public DateOnly? BeforeLastMaintenance { get; set; }

}