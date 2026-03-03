using Fireforce.Models;
using Fireforce.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Fireforce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll() {
            IEnumerable<Dept> result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            try
            {
                Dept result = await _service.GetByIdAsync(id);
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

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Dept dto) //later on might change it to [FromForm]
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var dept = new Dept
            {
                Voivodeship = dto.Voivodeship,
                PostalCode = dto.PostalCode,
                Street = dto.Street,
                Bnumber = dto.Bnumber,
                Aptnumber = dto.Aptnumber,
            };

            await _service.AddAsync(dept);
            return Ok(dept);
        }
    }
}
