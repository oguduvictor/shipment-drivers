using Microsoft.AspNetCore.Mvc;
using Protium.Digital.Domain.Dtos;
using Protium.Digital.Domain.Interfaces.Services;

namespace Protium.Digital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<ShipmentDto>> GetAll([FromQuery]int page = 1)
        {
            return await _shipmentService.GetAsync(page);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _shipmentService.GetById(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] CreateShipmentDto model)
        {
            return await _shipmentService.CreateAsync(model);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] UpdateShipmentDto model)
        {
            await _shipmentService.UpdateAsync(id, model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _shipmentService.DeleteAsync(id);
        }
    }
}