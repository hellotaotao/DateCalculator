using System;
using DateCalculate.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DateCalculate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeParseController : ControllerBase
    {
        // GET: api/<DaysController>
        [HttpGet]
        public IActionResult Get([FromQuery] DateTimeParseRequest dtr)
        {
            var dt = DateTime.Parse(dtr.Dt);
            return Ok(dt.ToString());
        }
    }

    public class DateTimeParseRequest
    {
        public string Dt { get; set; }
    }
}
