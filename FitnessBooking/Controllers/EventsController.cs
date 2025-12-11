using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var events = new[]
            {
            new {
                id = 1,
                title = "パーソナル(佐藤)",
                start = "2025-09-13T10:00:00",
                end   = "2025-09-13T11:00:00",
                trainerId = 1
            },
            new {
                id = 2,
                title = "パーソナル(田中)",
                start = "2025-09-13T12:00:00",
                end   = "2025-09-13T13:00:00",
                trainerId = 2
            }
        };
            return Ok(events);
        }
    }
}