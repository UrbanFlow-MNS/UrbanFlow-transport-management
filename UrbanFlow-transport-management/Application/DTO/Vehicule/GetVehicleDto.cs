namespace UrbanFlow_transport_management.DTO.Vehicule;

public class GetVehicleDto
{
    public int VehiculeId { get; set; }
    public int AgencyId { get; set; }
    public string RegistrationNumber { get; set; }
    public int RouteTypeId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateOnly ServiceDebut { get; set; }
    public int SeatsCount { get; set; }
    public int MaxCapacity { get; set; }
    public string Status { get; set; }
    public DateOnly LastMaintenance { get; set; }
    public DateOnly NextMaintenance { get; set; }
}