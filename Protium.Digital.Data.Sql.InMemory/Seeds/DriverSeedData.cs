using Protium.Digital.Domain.Entities;

namespace Protium.Digital.Data.Sql.InMemory.Seeds;

internal static class DriverSeedData
{
    internal static IEnumerable<Driver> Get => new List<Driver>
    {
        new Driver
        {
            Id = "EU.EORI.BUDR0000003",
            FirstName = "John",
            LastName = "Collins",
            VehiclePlate = "65438",
            StartDate = new DateTime(2022, 06, 09),
            ExpirationDate = 
                new DateTime(2022, 06, 09),
            CreatedBy = new DateTime(2022, 06, 09, 11, 02, 55),
            UpdatedBy = new DateTime(2022, 06, 09, 11, 02, 55),
            Active = true
        },
        new Driver
        {
            Id = "EU.EORI.BUDR0000004",
            FirstName = "Paul",
            LastName = "Young",
            VehiclePlate = "58974",
            StartDate = new DateTime(2022, 06, 09),
            ExpirationDate = 
                new DateTime(2022, 06, 09),
            CreatedBy = new DateTime(2022, 06, 09, 11, 02, 55),
            UpdatedBy = new DateTime(2022, 06, 09, 11, 02, 55),
            Active = true
        }
    };
}