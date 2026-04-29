using Grpc.Core;
using UrbanFlow_transport_management.DTO.RouteType;
using UrbanFlow_transport_management.Repository;
using UrbanFlow_trips;

namespace UrbanFlow_transport_management.API.GrpcServices;

public class VehicleService(IRouteTypeRepository repo) : Vehicler.VehiclerBase
{
    public override async Task<VehicleResponse> FindById(VehicleRequest request, ServerCallContext context)
    {
        var trip = await repo.GetRouteTypeById(request.Id);
        return new VehicleResponse()
        {
            VehicleName = trip?.Name,
        };
    }
}