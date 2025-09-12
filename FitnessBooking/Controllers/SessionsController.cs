using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessBooking.Data;

namespace FitnessBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SessionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetSessions()
        {
            var sessions = await _db.Sessions
                .Select(s => new {
                    id = s.Id,
                    title = s.Title,
                    start = s.Start,
                    end = s.End
                })
                .ToListAsync();

            return Ok(sessions);
        }
    }
}
