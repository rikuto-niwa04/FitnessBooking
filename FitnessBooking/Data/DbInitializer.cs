using FitnessBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessBooking.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await db.Database.MigrateAsync();

        if (await db.Clients.AnyAsync()) return; // 2回目以降はスキップ

        db.Clients.AddRange(
            new Client { Name = "Alice", Email = "alice@example.com" },
            new Client { Name = "Bob", Email = "bob@example.com" }
        );
        db.Trainers.AddRange(
            new Trainer { Name = "Taro", Email = "taro@example.com" }
        );
        await db.SaveChangesAsync();
    }
}