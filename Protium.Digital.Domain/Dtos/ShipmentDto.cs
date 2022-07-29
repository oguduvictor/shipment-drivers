using Protium.Digital.Domain.Entities;
using Protium.Digital.Domain.Enums;

namespace Protium.Digital.Domain.Dtos;

public class ShipmentDto
{
    public ShipmentDto(Shipment shipment)
    {
        Id = shipment.Id;
        Comments = shipment.Comments;
        Destination = shipment.Destination;
        Origin = shipment.Origin;
        Status = shipment.Status;
        AssociatedBarcode = shipment.AssociatedBarcode;
        CreatedAt = shipment.CreatedAt;
        CreatedBy = shipment.CreatedBy;
        DriverId = shipment.DriverId;
        EffectiveDate = shipment.EffectiveDate;
        PlannedDate = shipment.PlannedDate;
        ShipmentDate = shipment.ShipmentDate;
        UpdatedAt = shipment.UpdatedAt;
        UpdatedBy = shipment.UpdatedBy;
    }
    
    public string Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public ShipmentStatusEnum Status { get; set; }
    public DateTime? ShipmentDate { get; set; }
    public string DriverId { get; set; }
    public DateTime? PlannedDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string Comments { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public string AssociatedBarcode { get; set; }
}