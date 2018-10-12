using System.Linq;
using TaskPlanner.Models;

namespace TaskPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.TaskRotations.Any())
            {
                return;
            }

            var taskRotations = new TaskRotation[]
            {
                new TaskRotation { TaskRotationId = 1, Name = "None" },
                new TaskRotation { TaskRotationId = 2, Name = "Hourly" },
                new TaskRotation { TaskRotationId = 3, Name = "Daily" },
                new TaskRotation { TaskRotationId = 4, Name = "Weekly" },
                new TaskRotation { TaskRotationId = 5, Name = "Monthly" }
            };

            foreach (var taskRotation in taskRotations)
            {
                context.TaskRotations.Add(taskRotation);
            }
            context.SaveChanges();
        }
    }
}
