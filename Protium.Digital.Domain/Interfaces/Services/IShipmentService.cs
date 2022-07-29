using Protium.Digital.Domain.Dtos;

namespace Protium.Digital.Domain.Interfaces.Services;

public interface IShipmentService
{
    Task<ShipmentDto?> GetById(string id);

    Task<IEnumerable<ShipmentDto>> GetAsync(int page);

    Task<string> CreateAsync(CreateShipmentDto createShipmentDto);

    Task UpdateAsync(string id, UpdateShipmentDto updateShipmentDto);

    Task DeleteAsync(string id);
}