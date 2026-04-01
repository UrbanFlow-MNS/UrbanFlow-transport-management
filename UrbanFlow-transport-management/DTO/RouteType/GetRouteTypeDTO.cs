namespace UrbanFlow_transport_management.DTO.RouteType;

public class GetRouteTypeDto
{
    public int RouteTypeId { get; set; }
    public required string Name { get; set; }
    public int AgencyId { get; set; }

}