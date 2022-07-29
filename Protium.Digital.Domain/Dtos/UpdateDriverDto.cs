namespace Protium.Digital.Domain.Dtos;

public class UpdateDriverDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? VehiclePlate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool? Active { get; set; }
}