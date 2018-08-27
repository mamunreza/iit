using System.Collections.Generic;
using TaskPlanner.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Data.Interface
{
    public interface ITaskRotationRepository
    {
        void Create(TaskRotationViewModel vm);
        void Edit(TaskRotationViewModel vm);
        ICollection<TaskRotationViewModel> List();
        TaskRotation GetById(int id);
    }
}
