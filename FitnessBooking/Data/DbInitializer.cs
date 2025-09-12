using FitnessBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessBooking.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await db.Database.MigrateAsync();

            // --- Clients / Trainers が無ければ投入 ---
            if (!await db.Clients.AnyAsync())
            {
                db.Clients.AddRange(
                    new Client { Name = "Alice", Email = "alice@example.com" },
                    new Client { Name = "Bob", Email = "bob@example.com" }
                );
            }

            if (!await db.Trainers.AnyAsync())
            {
                db.Trainers.AddRange(
                    new Trainer { Name = "Taro", Email = "taro@example.com" },
                    new Trainer { Name = "Hanako", Email = "hanako@example.com" }
                );
            }

            await db.SaveChangesAsync();

            // --- Sessions が無ければ投入 ---
            if (!await db.Sessions.AnyAsync())
            {
                var alice = await db.Clients.FirstAsync(c => c.Name == "Alice");
                var bob = await db.Clients.FirstAsync(c => c.Name == "Bob");
                var taro = await db.Trainers.FirstAsync(t => t.Name == "Taro");

                db.Sessions.AddRange(
                    new Session
                    {
                        ClientId = alice.Id,
                        TrainerId = taro.Id,
                        Title = "パーソナルトレーニング (Alice)",
                        Start = DateTime.Today.AddHours(10),
                        End = DateTime.Today.AddHours(11)
                    },
                    new Session
                    {
                        ClientId = bob.Id,
                        TrainerId = taro.Id,
                        Title = "パーソナルトレーニング (Bob)",
                        Start = DateTime.Today.AddDays(1).AddHours(14),
                        End = DateTime.Today.AddDays(1).AddHours(15)
                    }
                );

                await db.SaveChangesAsync();
            }
        }
    }
}