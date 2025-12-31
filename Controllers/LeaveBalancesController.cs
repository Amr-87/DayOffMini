using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveBalancesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBalances()
        {
            return Ok("This is a placeholder for LeaveBalancesController.");
        }
    }
}
