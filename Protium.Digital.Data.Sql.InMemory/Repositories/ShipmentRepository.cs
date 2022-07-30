using Microsoft.EntityFrameworkCore;
using Protium.Digital.Domain.Entities;
using Protium.Digital.Domain.Interfaces.Repositories;

namespace Protium.Digital.Data.Sql.InMemory.Repositories;

internal class ShipmentRepository : IShipmentRepository
{
    private readonly AppDbContext _dbContext;

    public ShipmentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Shipment>> GetAsync(int skip, int take)
    {
        return await _dbContext.Shipments.Include(x => x.Driver).AsNoTracking()
            .Skip(skip).Take(take)
            .ToListAsync();
    }

    public async Task<Shipment?> GetByIdAsync(string id)
    {
        return await _dbContext.Shipments.Include(x => x.Driver).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<string> CreateAsync(Shipment shipment)
    {
        _dbContext.Shipments.Add(shipment);

        await _dbContext.SaveChangesAsync();

        return shipment.Id;
    }

    public async Task UpdateAsync(Shipment shipment)
    {
        _dbContext.Shipments.Update(shipment);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Shipment shipment)
    {
        _dbContext.Shipments.Update(shipment);

        await _dbContext.SaveChangesAsync();
    }
}