using Protium.Digital.Domain.Dtos;
using Protium.Digital.Domain.Entities;
using Protium.Digital.Domain.Interfaces.Repositories;
using Protium.Digital.Domain.Interfaces.Services;
using Protium.Digital.Shared.Extensions;
using Protium.Digital.Shared.Helpers;

namespace Protium.Digital.Services;

internal class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _shipmentRepository;

    public ShipmentService(IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<ShipmentDto?> GetById(string id)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(id);

        return shipment is not null ? new ShipmentDto(shipment) : null;
    }

    public async Task<IEnumerable<ShipmentDto>> GetAsync(int page)
    {
        const int numberPerPage = 50;

        var shipments = await _shipmentRepository.GetAsync((page- 1) * numberPerPage, numberPerPage);

        return shipments.Select(x => new ShipmentDto(x));
    }

    public async Task<string> CreateAsync(CreateShipmentDto createShipmentDto)
    {
        var shipment = createShipmentDto.Cast<Shipment>();

        shipment.Id = StringHelpers.GenerateEntityId();

        shipment.CreatedBy = Guid.NewGuid().ToString();
        shipment.UpdatedBy = Guid.NewGuid().ToString();
        shipment.CreatedAt = DateTime.UtcNow;
        shipment.UpdatedAt = DateTime.UtcNow;

        return await _shipmentRepository.CreateAsync(shipment);
    }

    public async Task UpdateAsync(string id, UpdateShipmentDto updateShipmentDto)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(id);

        if (shipment == null)
        {
            throw new NullReferenceException();
        }
        
        shipment.CopyFromSourceToTarget(updateShipmentDto);

        shipment.UpdatedBy = Guid.NewGuid().ToString();
        shipment.UpdatedAt = DateTime.UtcNow;

        await _shipmentRepository.UpdateAsync(shipment);
    }

    public async Task DeleteAsync(string id)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(id);

        if (shipment == null)
        {
            return;
        }

        await _shipmentRepository.DeleteAsync(shipment);
    }
}