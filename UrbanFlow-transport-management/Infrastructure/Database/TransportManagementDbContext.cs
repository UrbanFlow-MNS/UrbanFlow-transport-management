using Microsoft.EntityFrameworkCore;
using UrbanFlow_transport_management.Domain.Models;

namespace UrbanFlow_transport_management.Infrastructure.Database;

public class TransportManagementDbContext : DbContext
{
    public TransportManagementDbContext(DbContextOptions<TransportManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<VehiculePosition> VehiculePositions { get; set; }
    public DbSet<Vehicule> Vehicules { get; set; }
    public DbSet<RouteType> RouteTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicule>(entity =>
        {
            entity.HasKey(v => v.VehiculeId);

            entity.Property(v => v.RegistrationNumber).IsRequired();
            entity.Property(v => v.Brand).IsRequired();
            entity.Property(v => v.Model).IsRequired();

            entity.HasOne(v => v.RouteType)
                .WithMany(rt => rt.Vehicules)
                .HasForeignKey(v => v.RouteTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<VehiculePosition>(entity =>
        {
            entity.HasKey(vp => vp.VehiculePositionId);

            entity.Property(vp => vp.Longitude)
                .HasColumnType("decimal(9,6)")
                .IsRequired();

            entity.Property(vp => vp.Latitude)
                .HasColumnType("decimal(9,6)")
                .IsRequired();

            entity.HasOne(vp => vp.Vehicule)
                .WithMany(v => v.Positions)
                .HasForeignKey(vp => vp.VehiculeId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<RouteType>(entity =>
        {
            entity.HasKey(rt => rt.RouteTypeId);

            entity.Property(rt => rt.Name)
                .IsRequired();
        });
    }
}