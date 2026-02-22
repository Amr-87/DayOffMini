using Microsoft.AspNetCore.Mvc;

namespace DayOffMini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Test()
        {
            string message = "Api Works!";
            return Ok(message);
        }
    }
}
