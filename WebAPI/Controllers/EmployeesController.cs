using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("companyid/{id}")]
        public IActionResult GetByCompanyId(int id)
        {
            var result = _employeeService.GetByCompanyId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            var result = _employeeService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            var result = _employeeService.Add(employee);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(new Employee { Id = id });
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("id/{id}")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            employee.Id = id;
            var result = _employeeService.Update(employee);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}