using Microsoft.EntityFrameworkCore;
using TaskPlanner.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TaskRotation> TaskRotations { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<TaskHistory> TaskHistorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .Property(b => b.Active)
                .HasDefaultValue(true);
        }

        public DbSet<TaskPlanner.ViewModels.TaskScheduleViewModel> TaskScheduleViewModel { get; set; }
    }
}
