using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrbanFlow_transport_management.Database;
using UrbanFlow_transport_management.Domain.Enum;
using UrbanFlow_transport_management.DTO.Vehicule;
using UrbanFlow_transport_management.Models;
using static System.Enum;

namespace UrbanFlow_transport_management.Repository;

public class VehicleRepository(TransportManagementDbContext db, IMapper  mapper) : IVehicleRepository
{
    public async Task<List<Vehicule>> GetAllVehiclesByAgencyIdAsync(int agencyId)
    {
        return await db.Vehicules.Where(x => x.AgencyId == agencyId).ToListAsync();
    }

    public async Task<Vehicule?> GetVehicleById(int id)
    {
        return await db.Vehicules.FindAsync(id);
    }

    public async Task CreateVehicleAsync(CreateVehiculeDto vehiculeDto)
    {
        ArgumentNullException.ThrowIfNull(vehiculeDto);

        var vehicule = mapper.Map<Vehicule>(vehiculeDto);
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
    
    public async Task<List<GetVehiculeDto>> GetVehiclesByAgencyIdWithFilters(VehicleFilterDto filter, int id)
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
            query = query.Where(v => v.Statut == filter.Status);
        
        if (filter.BeforeLastMaintenance != null)
            query = query.Where(v => v.LastMaintenance <= filter.BeforeLastMaintenance);
        
        
        await query.AsNoTracking().ToListAsync();
        return mapper.Map<List<GetVehiculeDto>>(query);
    }

    public async Task ArchiveVehicule(int id)
    {
        var vehicle = await GetVehicleById(id);
    }


    public IEnumerable<VehicleStatusDto> GetVehicleStatus()
    {
        return Enum.GetValues<VehicleStatus>()
            .Select(s => new VehicleStatusDto((int)s, s.ToString()));
    }
    
    
    
    
}