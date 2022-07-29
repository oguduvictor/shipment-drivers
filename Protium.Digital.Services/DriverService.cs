using Protium.Digital.Domain.Dtos;
using Protium.Digital.Domain.Entities;
using Protium.Digital.Domain.Interfaces.Repositories;
using Protium.Digital.Domain.Interfaces.Services;
using Protium.Digital.Shared.Extensions;
using Protium.Digital.Shared.Helpers;

namespace Protium.Digital.Services;

internal class DriverService : IDriverService
{
    private readonly IDriverRepository _driverRepository;

    public DriverService(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<IEnumerable<DriverDto>> GetAsync(int page)
    {
        const int numberPerPage = 50;

        var drivers = await _driverRepository.GetAsync((page - 1) * numberPerPage, numberPerPage);

        return drivers.Select(d => new DriverDto(d));
    }

    public async Task<DriverDto?> GetByIdAsync(string id)
    {
        var driver = await _driverRepository.GetByIdAsync(id);

        return driver is not null ? new DriverDto(driver) : null;
    }

    public async Task<string> CreateAsync(CreateDriverDto createDriverDto)
    {
        var driver = createDriverDto.Cast<Driver>();

        driver.Id = StringHelpers.GenerateEntityId();

        return await _driverRepository.CreateAsync(driver);
    }

    public async Task UpdateAsync(string id, UpdateDriverDto updateDriverDto)
    {
        var driver = await _driverRepository.GetByIdAsync(id);

        if (driver == null)
        {
            throw new NullReferenceException();
        }

        updateDriverDto.CopyFromSourceToTarget(driver);

        await _driverRepository.UpdateAsync(driver);
    }

    public async Task DeleteAsync(string id)
    {
        var driver = await _driverRepository.GetByIdAsync(id);

        if (driver == null)
        {
            return;
        }

        await _driverRepository.DeleteAsync(driver);
    }
}