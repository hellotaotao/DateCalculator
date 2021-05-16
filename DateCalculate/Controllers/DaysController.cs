using DateCalculate.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DateCalculate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        // GET: api/<DaysController>
        [HttpGet]
        public IActionResult Get([FromQuery] Request request)
        {
            var days = CalculateService.DaysCalculate(request);
            return Ok(days.ToString());
        }
    }
}
