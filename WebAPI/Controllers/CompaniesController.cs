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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _companyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _companyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(Company company)
        {
            var result = _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _companyService.Delete(new Company { Id = id });
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("id/{id}")]
        public IActionResult Update(int id, [FromBody] Company company)
        {
            company.Id = id;
            var result = _companyService.Update(company);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}