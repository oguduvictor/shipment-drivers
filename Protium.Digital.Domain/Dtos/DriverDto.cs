using Protium.Digital.Domain.Entities;

namespace Protium.Digital.Domain.Dtos;

public class DriverDto
{
    public DriverDto(Driver driver)
    {
        Id = driver.Id;
        FirstName = driver.FirstName;
        LastName = driver.LastName;
        VehiclePlate = driver.VehiclePlate;
        StartDate = driver.StartDate;
        ExpirationDate = driver.ExpirationDate;
        CreatedBy = driver.CreatedBy;
        UpdatedBy = driver.UpdatedBy;
        Active = driver.Active;
    }
    
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? VehiclePlate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public DateTime? CreatedBy { get; set; }
    public DateTime? UpdatedBy { get; set; }
    public bool? Active { get; set; }
}