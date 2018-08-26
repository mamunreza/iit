using System.Collections.Generic;
using System.Linq;
using TaskPlanner.Data.Interface;
using TaskPlanner.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Data.Repository
{
    public class TaskRotationRepository : ITaskRotationRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskRotationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(TaskRotationViewModel vm)
        {
            var taskRotation = new TaskRotation
            {
                Name = vm.Name
            };

            _appDbContext.TaskRotations.Add(taskRotation);
            _appDbContext.SaveChangesAsync();
        }

        public ICollection<TaskRotationViewModel> List()
        {
            var models = new List<TaskRotationViewModel>();
            var list = _appDbContext.TaskRotations.ToList();

            foreach (var item in list)
            {
                var model = new TaskRotationViewModel
                {
                    Name = item.Name
                };
                models.Add(model);
            }

            return models;
        }
    }
}
