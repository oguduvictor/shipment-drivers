using Protium.Digital.Domain.Dtos;
using Protium.Digital.Domain.Entities;

namespace Protium.Digital.Domain.Interfaces.Repositories;

public interface IDriverRepository
{
    Task<IEnumerable<Driver>> GetAsync(int skip, int take);
    Task<IEnumerable<NamedId>> GetSummariesAsync();
    Task<Driver?> GetByIdAsync(string id);
    Task<string> CreateAsync(Driver driver);
    Task UpdateAsync(Driver driver);
    Task DeleteAsync(Driver driver);
}