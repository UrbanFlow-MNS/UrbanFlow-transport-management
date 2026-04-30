namespace UrbanFlow_transport_management.Domain.Models;

public class RouteType
{
    public int RouteTypeId { get; set; }
    public string Name { get; set; }
    public int AgencyId { get; set; }
    public ICollection<Vehicule> Vehicules { get; set; }
}