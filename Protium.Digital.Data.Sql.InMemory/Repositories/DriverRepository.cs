using Microsoft.EntityFrameworkCore;
using Protium.Digital.Domain.Dtos;
using Protium.Digital.Domain.Entities;
using Protium.Digital.Domain.Interfaces.Repositories;

namespace Protium.Digital.Data.Sql.InMemory.Repositories;

internal class DriverRepository : IDriverRepository
{
    private readonly AppDbContext _dbContext;

    public DriverRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Driver>> GetAsync(int skip, int take)
    {
        return await _dbContext.Drivers.AsNoTracking()
            .Skip(skip).Take(take)
            .ToListAsync();
    }

    public async Task<IEnumerable<NamedId>> GetSummariesAsync()
    {
        return await _dbContext.Drivers.Select(x => new NamedId { Id = x.Id, Name = $"{x.FirstName} {x.LastName}" }).ToListAsync();
    }

    public async Task<Driver?> GetByIdAsync(string id)
    {
        return await _dbContext.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<string> CreateAsync(Driver driver)
    {
        _dbContext.Drivers.Add(driver);

        await _dbContext.SaveChangesAsync();

        return driver.Id;
    }

    public async Task UpdateAsync(Driver driver)
    {
        _dbContext.Drivers.Update(driver);

        // _dbContext.Entry(driver).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Driver driver)
    {
        _dbContext.Drivers.Remove(driver);

        await _dbContext.SaveChangesAsync();
    }
}