using FitnessBooking.Data;
using FitnessBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessBooking.Services;

public interface ISchedulingService
{
    Task<TrainingSession?> BookAsync(int clientId, int trainerId, DateTime start, DateTime end);
}

public class SchedulingService(ApplicationDbContext db, IConflictChecker checker) : ISchedulingService
{
    public async Task<TrainingSession?> BookAsync(int clientId, int trainerId, DateTime start, DateTime end)
    {
        var sameDay = await db.TrainingSessions
            .Where(s => s.TrainerId == trainerId && s.Start.Date == start.Date)
            .ToListAsync();

        if (checker.HasConflict(sameDay, start, end, trainerId)) return null;

        var ses = new TrainingSession { ClientId = clientId, TrainerId = trainerId, Start = start, End = end };
        db.TrainingSessions.Add(ses);
        await db.SaveChangesAsync();
        return ses;
    }
}
