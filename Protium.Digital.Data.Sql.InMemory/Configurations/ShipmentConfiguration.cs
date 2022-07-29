using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Protium.Digital.Data.Sql.InMemory.Seeds;
using Protium.Digital.Domain.Entities;

namespace Protium.Digital.Data.Sql.InMemory.Configurations;

internal sealed class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Driver).WithMany().HasForeignKey(x => x.DriverId).IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.AssociatedBarcode).IsRequired(false);
        builder.Property(x => x.Destination).IsRequired(false);
        builder.Property(x => x.Origin).IsRequired(false);

        builder.HasData(ShipmentSeedData.Get);
    }
}