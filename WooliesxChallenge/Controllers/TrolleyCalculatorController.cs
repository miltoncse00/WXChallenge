using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WooliesxChallenge.Application;
using WooliesxChallenge.Domain;

namespace WooliesxChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleyCalculatorController : ControllerBase
    {
        private readonly ITrolleyCalculatorService _trolleyCalculatorService;

        public TrolleyCalculatorController(ITrolleyCalculatorService trolleyCalculatorService)
        {
            _trolleyCalculatorService = trolleyCalculatorService;
        }

        [HttpPost("TrolleyTotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> CalculateTotal([FromBody] TrolleyRequest trolleyRequest)
        {

            var products =  _trolleyCalculatorService.CalculateTotal(trolleyRequest);
            return Ok(products);
        }
    }
}
