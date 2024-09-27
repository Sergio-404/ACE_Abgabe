using Microsoft.AspNetCore.Mvc;

namespace Ace_Aufgabe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] int n)
        {
            if (n < 0 || n > 50)
                return BadRequest("Value should be between 0 and 50.");

            long precedingSumNumber = SumSequence(n);
            return Ok(new { number = precedingSumNumber });
        }

        private long SumSequence(int n)
        {
            if (n <= 1) return n;

            long prev1 = 0, prev2 = 1, result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = prev1 + prev2;
                prev1 = prev2;
                prev2 = result;
            }

            return result;
        }
    }
}
