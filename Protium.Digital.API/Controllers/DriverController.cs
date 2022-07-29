using Microsoft.AspNetCore.Mvc;
using Protium.Digital.Domain.Dtos;
using Protium.Digital.Domain.Interfaces.Services;

namespace Protium.Digital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IEnumerable<DriverDto>> GetAll(int page = 1)
        {
            return await _driverService.GetAsync(page);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _driverService.GetByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] CreateDriverDto model)
        {
            return await _driverService.CreateAsync(model);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] UpdateDriverDto model)
        {
            await _driverService.UpdateAsync(id, model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _driverService.DeleteAsync(id);
        }
    }
}
