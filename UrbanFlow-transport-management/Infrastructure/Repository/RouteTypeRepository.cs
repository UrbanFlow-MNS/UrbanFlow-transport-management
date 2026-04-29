using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrbanFlow_transport_management.Application.DTO.RouteType;
using UrbanFlow_transport_management.Domain.Interfaces;
using UrbanFlow_transport_management.Domain.Models;
using UrbanFlow_transport_management.Infrastructure.Database;

namespace UrbanFlow_transport_management.Infrastructure.Repository;

public class RouteTypeRepository(TransportManagementDbContext db, IMapper mapper) : IRouteTypeRepository
{
    
    public async Task CreateRouteTypeAsync(CreateRouteTypeDto routeTypeDto)
    {
        ArgumentNullException.ThrowIfNull(routeTypeDto);

        var routeType = mapper.Map<RouteType>(routeTypeDto);
        await db.RouteTypes.AddAsync(routeType);
        await db.SaveChangesAsync();
    }
    
    
    public async Task<GetRouteTypeDto?> GetRouteTypeById(int id)
    {
        var routetype = await db.RouteTypes.FindAsync(id);
        return mapper.Map<GetRouteTypeDto>(routetype);
    }
    
    public async Task<List<GetRouteTypeDto>> GetAllRouteTypesByAgencyIdAsync(int id)
    {
        var routeTypes = await db.RouteTypes.Where(x =>  x.AgencyId == id).AsNoTracking().ToListAsync();
        return mapper.Map<List<GetRouteTypeDto>>(routeTypes);
    }

    /*
    public async Task DeleteRouteType(int id)
    {
        var agency = await GetRouteTypeById(id);
        
        if (agency == null)
            throw new KeyNotFoundException($"Routetype with id {id} not found");
        
        db.RouteTypes.Remove(agency);
        await db.SaveChangesAsync();
    }
    */
    
    public async Task UpdateRouteTypeAsync(int id, UpdateRouteTypeDto routeTypeDto)
    {
        var routeType = await GetRouteTypeById(id);

        if (routeType == null)
            throw new KeyNotFoundException($"RouteType with id {id} not found");
        
        mapper.Map(routeTypeDto, routeType);
        
        await db.SaveChangesAsync();
    }
}