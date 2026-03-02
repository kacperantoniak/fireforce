using Fireforce.Models;
using Fireforce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet(Name = "GetDepartments")]
        public async Task<IActionResult> GetAll() {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
