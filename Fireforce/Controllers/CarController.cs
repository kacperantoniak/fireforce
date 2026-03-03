using Fireforce.Models;
using Fireforce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fireforce.Controllers
{
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

        //i'll do more later i'm done for today
    }
}
