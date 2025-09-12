using FitnessBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessBooking.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
        public DbSet<TrainingSession> TrainingSessions => Set<TrainingSession>();
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainingSession>()
                .HasIndex(s => new { s.TrainerId, s.Start, s.End });
        }
    }
}
