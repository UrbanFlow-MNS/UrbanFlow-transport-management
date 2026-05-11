using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrbanFlow_transport_management.Application.DTO.Vehicule;
using UrbanFlow_transport_management.Domain.Enum;
using UrbanFlow_transport_management.Domain.Interfaces;
using UrbanFlow_transport_management.Domain.Models;
using UrbanFlow_transport_management.Infrastructure.Database;

namespace UrbanFlow_transport_management.Infrastructure.Repository;

public class VehicleRepository(TransportManagementDbContext db, IMapper  mapper) : IVehicleRepository
{
    private async Task<List<Vehicule>> GetAllVehiclesByAgencyIdAsync(int agencyId)
    {
        return await db.Vehicules.Where(x => x.AgencyId == agencyId).ToListAsync();
    }

    private async Task<Vehicule?> GetVehicleById(int id)
    {
        return await db.Vehicules.FindAsync(id);
    }

    public async Task CreateVehicleAsync(CreateVehicleDto vehicleDto)
    {
        ArgumentNullException.ThrowIfNull(vehicleDto);

        var vehicule = mapper.Map<Vehicule>(vehicleDto);
        await db.Vehicules.AddAsync(vehicule);
        await db.SaveChangesAsync();
    }

    public int NumberOfVehiclesByAgencyId(int agencyId)
    {
        return db.Vehicules.Count(x => x.AgencyId == agencyId);
    }

    public async Task? DeleteVehicle(int id)
    {
        var vehicle = await GetVehicleById(id);
        if (vehicle == null)
            return;
        db.Vehicules.Remove(vehicle);
        await db.SaveChangesAsync();
    }
    
    public async Task<List<GetVehicleDto>> GetVehiclesByAgencyIdWithFilters(VehicleFilterDto filter, int id)
    {
        ArgumentNullException.ThrowIfNull(filter);

        var query = db.Vehicules.Where(x => x.AgencyId == id).AsQueryable();
        
        if (filter.RegistrationNumber != null)
            query = query.Where(v => v.RegistrationNumber == filter.RegistrationNumber);
        
        if (filter.Brand != null)
            query = query.Where(v => v.Brand == filter.Brand);
        
        if (filter.Model != null)
            query = query.Where(v => v.Model == filter.Model);
        
        if (filter.Status != null)
            query = query.Where(v => v.Status == filter.Status);
        
        if (filter.BeforeLastMaintenance != null)
            query = query.Where(v => v.LastMaintenance <= filter.BeforeLastMaintenance);
        
        
        await query.AsNoTracking().ToListAsync();
        return mapper.Map<List<GetVehicleDto>>(query);
    }

    public async Task UpdateVehicleStatus(int id, VehicleStatus status)
    {
        var vehicle = await GetVehicleById(id);
        if (vehicle == null)
            return;
        vehicle.Status = status;
        await db.SaveChangesAsync();
    }

    public async Task UpdateVehicle(int id, UpdateVehicleDto vehicleDto)
    {
        ArgumentNullException.ThrowIfNull(vehicleDto);
        
        var vehicle = await GetVehicleById(id);
        if (vehicle == null)
            throw new KeyNotFoundException($"Vehicle with id {id} not found");
        
        mapper.Map(vehicleDto, vehicle);
        await db.SaveChangesAsync();
    }

    public IEnumerable<VehicleStatusDto> GetVehicleStatus()
    {
        return Enum.GetValues<VehicleStatus>()
            .Select(s => new VehicleStatusDto((int)s, s.ToString()));
    }
}