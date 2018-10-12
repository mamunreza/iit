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
            var model = new TaskRotation
            {
                Name = vm.Name
            };

            _appDbContext.TaskRotations.Add(model);
            _appDbContext.SaveChanges();
        }

        public void Edit(TaskRotationViewModel vm)
        {
            var entity = _appDbContext.TaskRotations.SingleOrDefault(x => x.TaskRotationId == vm.Id);
            entity.Name = vm.Name;
            _appDbContext.SaveChanges();
        }

        public TaskRotation GetById(int id)
        {
            var entity = _appDbContext.TaskRotations.SingleOrDefault(x => x.TaskRotationId == id);
            return entity;
        }

        public ICollection<TaskRotationViewModel> List()
        {
            var models = new List<TaskRotationViewModel>();
            var list = _appDbContext.TaskRotations.ToList();

            foreach (var item in list)
            {
                var model = new TaskRotationViewModel
                {
                    Id = item.TaskRotationId,
                    Name = item.Name
                };
                models.Add(model);
            }

            return models;
        }
    }
}
