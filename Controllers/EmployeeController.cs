using DapperDBFirst.Models;
using DapperDBFirst.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DapperDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        //creating our method
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list = await this.repo.GetAll();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetbyCode/{code}")]
        public async Task<IActionResult> GetbyCode(int code)
        {
            var _list = await this.repo.GetbyCode(code);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var result = await this.repo.Create(employee);
            return Ok(result);
            
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Employee employee, int code)
        {
            var result = await this.repo.Update(employee, code);
            return Ok(result);

        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int code)
        {
            var result = await this.repo.Remove(code);
            return Ok(result);

        }
    }
}
