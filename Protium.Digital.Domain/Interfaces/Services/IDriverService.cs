using Protium.Digital.Domain.Dtos;

namespace Protium.Digital.Domain.Interfaces.Services;

public interface IDriverService
{
    Task<IEnumerable<DriverDto>> GetAsync(int page);
    Task<IEnumerable<NamedId>> GetSummariesAsync();
    Task<DriverDto?> GetByIdAsync(string id);
    Task<string> CreateAsync(CreateDriverDto createDriverDto);
    Task UpdateAsync(string id, UpdateDriverDto updateDriverDto);
    Task DeleteAsync(string id);
}