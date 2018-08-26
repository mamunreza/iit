using System.Collections.Generic;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Data.Interface
{
    public interface ITaskRotationRepository
    {
        void Create(TaskRotationViewModel vm);
        ICollection<TaskRotationViewModel> List();
    }
}
