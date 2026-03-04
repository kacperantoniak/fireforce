using Fireforce.Models;
using Fireforce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fireforce.Controllers
{//redundat, creating generic controller base that ll make code cleaner
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;
        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Car> result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Car result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Accepted();
        }
    }
}
