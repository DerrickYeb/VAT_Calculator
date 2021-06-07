using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatCalculatorApi.DAL.Contracts;
using VatCalculatorApi.DAL.Models;

namespace ValueAddedTaxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatController : ControllerBase
    {
        private readonly ILogger<VatController> _logger;
        private readonly ICalculateVatRepository _repo;
        public VatController(ICalculateVatRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("calculate/value/added/tax")]
        public IActionResult CalculateValueAddedTax([FromBody] UserInputsModel inputs)
        {
            try
            {
                UserOutputModel output = null;
                if (!ModelState.IsValid)
                {
                    return BadRequest(inputs);
                }
                var result = _repo.CalculateValueAddedTax(inputs);
                output = result;
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured while executing {MethodName}-{Input} {Trace}\n");
                return null;
            }
        }
    }
}
