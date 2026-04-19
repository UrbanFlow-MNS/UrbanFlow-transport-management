namespace UrbanFlow_transport_management.DTO.Vehicule;

public class CreateVehiculeDto
{
    public int AgencyId { get; set; }
    public required string RegistrationNumber { get; set; }
    public required int RouteTypeId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public required DateOnly ServiceDebut { get; set; }
    public int? SeatsCount { get; set; }
    public int? MaxCapacity { get; set; }
    public string Status { get; set; } = "En ligne";
    public DateOnly? LastMaintenance { get; set; }
    public DateOnly? NextMaintenance { get; set; }
}