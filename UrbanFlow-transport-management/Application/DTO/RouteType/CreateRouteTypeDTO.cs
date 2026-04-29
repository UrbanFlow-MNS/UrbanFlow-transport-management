namespace UrbanFlow_transport_management.Application.DTO.RouteType;

public class CreateRouteTypeDto
{
    public required string Name { get; set; }
    public int AgencyId { get; set; }
}