namespace Protium.Digital.Domain.Entities;

public class Driver
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string VehiclePlate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public DateTime? CreatedBy { get; set; }
    public DateTime? UpdatedBy { get; set; }
    public bool Active { get; set; }
}