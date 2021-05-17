using DateCalculate.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DateCalculate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekdaysController : ControllerBase
    {
        private readonly ICalculateService calculateService;
        public WeekdaysController(ICalculateService service)
        {
            calculateService = service;
        }
        // GET: api/<DaysController>
        [HttpGet, HttpPost]
        public IActionResult Get([FromQuery] Request request)
        {
            var days = calculateService.WeekdaysCalculate(request);
            return Ok(days.ToString());
        }
    }
}
