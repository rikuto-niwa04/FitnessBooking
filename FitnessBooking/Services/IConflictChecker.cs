using FitnessBooking.Domain.Entities;

namespace FitnessBooking.Services;

public interface IConflictChecker
{
    bool HasConflict(IEnumerable<TrainingSession> existing, DateTime start, DateTime end, int trainerId);
}

public class ConflictChecker : IConflictChecker
{
    public bool HasConflict(IEnumerable<TrainingSession> existing, DateTime start, DateTime end, int trainerId)
    {
        // [start, end) の区間が1つでも重なれば衝突
        return existing.Any(s => s.TrainerId == trainerId && !(end <= s.Start || start >= s.End));
    }
}
