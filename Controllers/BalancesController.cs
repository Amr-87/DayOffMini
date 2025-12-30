using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBalances()
        {
            return Ok("This is a placeholder for BalancesController.");
        }
    }
}
