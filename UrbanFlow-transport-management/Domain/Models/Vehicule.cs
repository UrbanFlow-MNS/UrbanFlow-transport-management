using UrbanFlow_transport_management.Domain.Enum;

namespace UrbanFlow_transport_management.Models;

public class Vehicule
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
    public VehicleStatus Statut { get; set; }
    public DateOnly LastMaintenance { get; set; }
    public DateOnly NextMaintenance { get; set; }
    public RouteType RouteType { get; set; }
    public ICollection<VehiculePosition> Positions { get; set; }

}