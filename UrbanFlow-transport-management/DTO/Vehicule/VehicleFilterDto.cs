namespace UrbanFlow_transport_management.DTO.Vehicule;

public class VehicleFilterDto
{
    public string? RegistrationNumber { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Status { get; set; }
    public DateOnly? BeforeLastMaintenance { get; set; }

}