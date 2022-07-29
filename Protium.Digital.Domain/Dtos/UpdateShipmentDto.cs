using Protium.Digital.Domain.Enums;

namespace Protium.Digital.Domain.Dtos;

public class UpdateShipmentDto
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public ShipmentStatusEnum Status { get; set; }
    public DateTime? ShipmentDate { get; set; }
    public string DriverId { get; set; }
    public DateTime? PlannedDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string Comments { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string AssociatedBarcode { get; set; }
}