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
    public class IsoftAccountsController : ControllerBase
    {
        private readonly IIsoftAccountService _softAccountsService;

        public IsoftAccountsController(IIsoftAccountService softAccountsService)
        {
            _softAccountsService = softAccountsService;
        }

        [HttpGet("companyid/{id}")] //api/softaccounts/companyid/1
        public IActionResult GetByCompanyId(int id)
        {
            var result = _softAccountsService.GetByCompanyId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("id/{id}")] //api/softaccounts/id/1
        public IActionResult Get(int id)
        {
            var result = _softAccountsService.Get(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(IsoftAccount isoftAccount)
        {
            var result = _softAccountsService.Add(isoftAccount);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("id/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _softAccountsService.Delete(new IsoftAccount { Id = id });
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("id/{id}")]
        public IActionResult Update(int id, [FromBody] IsoftAccount isoftAccount)
        {
            isoftAccount.Id = id;
            var result = _softAccountsService.Update(isoftAccount);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


    }
}