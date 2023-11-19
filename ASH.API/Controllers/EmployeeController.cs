using ASH.COMMON.Models;
using ASH.DATA.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASH.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private int userId = 1;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("Employee")]
        public IActionResult Get()
        {
            return Ok(_employeeService.Get());
        }

        [HttpPost("Employee")]
        public IActionResult Add([FromBody] Employee request)
        {
            return Ok(_employeeService.Save(request, userId));
        }

        [HttpPut("Employee/{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Employee request)
        {
            return Ok(_employeeService.Save(request, userId));
        }
        [HttpDelete("Employee/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_employeeService.Delete(id));
        }

    }
}
