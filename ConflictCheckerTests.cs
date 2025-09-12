using FitnessBooking.Domain.Entities;
using FitnessBooking.Services;

namespace FitnessBooking.Tests;

public class ConflictCheckerTests
{
    [Fact]
    public void Overlap_ReturnsTrue()
    {
        var checker = new ConflictChecker();
        var existing = new List<TrainingSession>
        {
            new() {
                TrainerId = 1,
                Start = DateTime.Parse("2025-01-01T10:00:00"),
                End   = DateTime.Parse("2025-01-01T11:00:00")
            }
        };

        var result = checker.HasConflict(
            existing,
            DateTime.Parse("2025-01-01T10:30:00"),
            DateTime.Parse("2025-01-01T11:30:00"),
            1
        );

        Assert.True(result);
    }
}
