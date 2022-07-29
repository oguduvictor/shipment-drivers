using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Protium.Digital.Data.Sql.InMemory.Seeds;
using Protium.Digital.Domain.Entities;

namespace Protium.Digital.Data.Sql.InMemory.Configurations;

internal sealed class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(DriverSeedData.Get);
    }
}