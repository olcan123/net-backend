using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalariesController : ControllerBase
    {
        private readonly ISalaryLineService _salaryLineService;
        private readonly ISalaryHeadService _salaryHeadService;

        public SalariesController(ISalaryLineService salaryLineService, ISalaryHeadService salaryHeadService)
        {
            _salaryLineService = salaryLineService;
            _salaryHeadService = salaryHeadService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _salaryHeadService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            var result = _salaryHeadService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(SalaryModel salary)
        {
            var result = _salaryLineService.BulkAdd(salary.SalaryHead, salary.SalaryLines);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _salaryLineService.DeleteBySalaryHeadId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("lines/id/{id}")]
        public IActionResult DeleteLines(int id)
        {
            var result = _salaryLineService.DeleteBySalaryLineId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("id/{id}")]
        public IActionResult Update(int id, [FromBody] SalaryModel salary)
        {
            salary.SalaryHead.Id = id;
            var result = _salaryLineService.BulkInsertOrUpdate(salary.SalaryHead, salary.SalaryLines);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}