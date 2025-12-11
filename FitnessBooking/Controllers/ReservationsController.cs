using FitnessBooking.Domain.Entities;
using FitnessBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(ISchedulingService scheduling) : ControllerBase
{
    public record BookRequest(int ClientId, int TrainerId, DateTime Start, DateTime End);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookRequest req)
    {
        TrainingSession? result = await scheduling.BookAsync(req.ClientId, req.TrainerId, req.Start, req.End);
        return result is null ? Conflict("Time slot already booked.") : Ok(result);
    }
}