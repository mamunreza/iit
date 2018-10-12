using System.Collections.Generic;
using TaskPlanner.Models;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Data.Interface
{
    public interface ITaskRepository
    {
        Task GetById(int id);
        void Create(TaskViewModel vm);
        void Edit(TaskViewModel vm);
        ICollection<TaskViewModel> List();
        void Delete(int id);
        ICollection<TaskScheduleViewModel> GetTaskSchedule();
        void MarkAsComplete(List<TaskScheduleViewModel> models);
    }
}
