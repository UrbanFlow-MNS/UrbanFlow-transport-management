namespace UrbanFlow_transport_management.DTO.RouteType;

public class CreateRouteTypeDto
{
    public required string Name { get; set; }
    public int AgencyId { get; set; }
}