using Microsoft.AspNetCore.Mvc;

namespace Ace_Aufgabe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TempController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] double celsius)
        {
            double kelvin = celsius + 273.15;
            return Ok(new { kelvin, celsius });
        }
    }
}
