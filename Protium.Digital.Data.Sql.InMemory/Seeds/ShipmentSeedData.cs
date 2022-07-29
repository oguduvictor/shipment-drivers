using Protium.Digital.Domain.Entities;
using Protium.Digital.Domain.Enums;

namespace Protium.Digital.Data.Sql.InMemory.Seeds;

internal static class ShipmentSeedData
{
    internal static IEnumerable<Shipment> Get => new List<Shipment>
    {
        new Shipment
        {
            Id = "22bb783d8c94431997ec7deba3920f10",
            Origin = "EU.EORI.BUWH0000001",
            Destination = "EU.EORI.BUNU0000005",
            Status = ShipmentStatusEnum.Init,
            ShipmentDate = new DateTime(2022, 06, 09),
            DriverId = "EU.EORI.BUDR0000003",
            PlannedDate = new DateTime(2022, 06, 09),
            EffectiveDate = new DateTime(2022, 06, 09),
            Comments = "Created by LastMile in Medexis",
            CreatedAt = new DateTime(2022, 04, 29, 10, 12, 20),
            CreatedBy = "87c496e2d06847828ff235e14e9bf137",
            UpdatedAt = new DateTime(2022, 06, 09, 11, 11, 07),
            UpdatedBy = "f346ba682de14ff5a4e3abd2f3a23a33"
        },
        new Shipment
        {
            Id = "0b112f986c084c07a287d1bddb61cd46",
            Origin = "EU.EORI.BUWH0000001",
            Destination = "EU.EORI.BUNU0000005",
            Status = ShipmentStatusEnum.Init,
            ShipmentDate = new DateTime(2022, 06, 09),
            DriverId = "EU.EORI.BUDR0000003",
            PlannedDate = new DateTime(2022, 06, 09),
            EffectiveDate = new DateTime(2022, 06, 09),
            Comments = "Created by LastMile in Medexis",
            AssociatedBarcode = "LM_Ship_f4600c34d7a24d86a836355790fc5c5c_58",
            CreatedAt = new DateTime(2022, 04, 29, 10, 12, 20),
            CreatedBy = "87c496e2d06847828ff235e14e9bf137",
            UpdatedAt = new DateTime(2022, 06, 09, 11, 02, 55),
            UpdatedBy = "f346ba682de14ff5a4e3abd2f3a23a33"
        }
    };
}