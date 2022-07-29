using Protium.Digital.Domain.Entities;

namespace Protium.Digital.Domain.Interfaces.Repositories;

public interface IShipmentRepository
{
    Task<List<Shipment>> GetAsync(int skip, int take);
    Task<Shipment?> GetByIdAsync(string id);
    Task<string> CreateAsync(Shipment shipment);
    Task UpdateAsync(Shipment shipment);
    Task DeleteAsync(Shipment shipment);
}