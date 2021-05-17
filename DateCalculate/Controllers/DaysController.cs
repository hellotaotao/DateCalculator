using DateCalculate.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DateCalculate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly ICalculateService calculateService;
        public DaysController(ICalculateService service)
        {
            calculateService = service;
        }
        // GET: api/<DaysController>
        [HttpGet]
        public IActionResult Get([FromQuery] Request request)
        {
            var days = calculateService.DaysCalculate(request);
            return Ok(days.ToString());
        }
    }
}
