namespace DefaultNamespace;

public class VehiculePosition
{
    public int VehiculePositionId { get; set; }
    public int VehiculeId { get; set; }
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public int TripId { get; set; }
    
    public Vehicule Vehicule { get; set; }
}