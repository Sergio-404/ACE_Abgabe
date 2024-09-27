using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ace_Aufgabe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] int limit)
        {
            if (limit > 10000)
                return BadRequest("Limit cannot exceed 10,000.");

            var primes = SieveOfEratosthenes(limit);
            return Ok(new { primes });
        }

        private List<int> SieveOfEratosthenes(int limit)
        {
            var primes = new List<int>();
            var sieve = new bool[limit + 1];
            for (int i = 2; i <= limit; i++) sieve[i] = true;

            for (int i = 2; i * i <= limit; i++)
            {
                if (sieve[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            for (int i = 2; i <= limit; i++)
            {
                if (sieve[i]) primes.Add(i);
            }

            return primes;
        }
    }
}
