using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlanner.Data.Interface;
using TaskPlanner.ViewModels;
using TaskPlanner.Models;

namespace TaskPlanner.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(TaskViewModel vm)
        {
            var model = new Models.Task
            {
                Active = true,
                DueDate = vm.DueDate,
                TaskName = vm.TaskName,
                TaskRotationId = vm.TaskRotationId
            };

            _appDbContext.Tasks.Add(model);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _appDbContext.Tasks.SingleOrDefault(x => x.TaskId == id);
            entity.Active = false;
            _appDbContext.SaveChanges();
        }

        public void Edit(TaskViewModel vm)
        {
            var entity = _appDbContext.Tasks.SingleOrDefault(x => x.TaskId == vm.Id);
            entity.TaskName = vm.TaskName;
            entity.DueDate = vm.DueDate;
            entity.TaskRotationId = vm.TaskRotationId;
            _appDbContext.SaveChanges();
        }

        public Models.Task GetById(int id)
        {
            var entity = _appDbContext.Tasks.SingleOrDefault(x => x.TaskId == id);
            return entity;
        }

        public ICollection<TaskViewModel> List()
        {
            var models = new List<TaskViewModel>();
            var list = _appDbContext.Tasks.Where(x => x.DueDate > DateTime.Now && x.Active)
                .Include(x => x.TaskRotation)
                .ToList();

            foreach (var item in list)
            {
                var model = new TaskViewModel
                {
                    Id = item.TaskId,
                    Active = item.Active,
                    DueDate = item.DueDate,
                    TaskName = item.TaskName,
                    TaskRotationId = item.TaskRotationId,
                    TaskRotationName = item.TaskRotation.Name
                };
                models.Add(model);
            }

            return models;
        }

        public ICollection<TaskScheduleViewModel> GetTaskSchedule()
        {
            var models = new List<TaskScheduleViewModel>();
            var list = _appDbContext.Tasks.Where(x => x.DueDate > DateTime.Now && x.Active)
                .Include(x => x.TaskRotation)
                .OrderBy(x => x.DueDate)
                .ToList();

            foreach (var item in list)
            {
                var model = new TaskScheduleViewModel
                {
                    Id = item.TaskId,
                    DueDate = item.DueDate,
                    TaskName = item.TaskName,
                    TimeRemaining = GetTimeDifference(item.DueDate)
                };
                models.Add(model);
            }

            return models;
        }

        public void MarkAsComplete(List<TaskScheduleViewModel> models)
        {
            var vm = new List<TaskScheduleViewModel>();
            var list = _appDbContext.Tasks.Where(x => x.DueDate > DateTime.Now && x.Active)
                .Include(x => x.TaskRotation)
                .OrderBy(x => x.DueDate)
                .ToList();
            // TODO: need to exclude tasks that are complete (are in history table)

            foreach (var item in list)
            {
                foreach(var model in models)
                {
                    if (model.Id == item.TaskId && model.IsComplete)
                    {
                        //TODO: add completed tasks in history
                    }
                }
            }

            _appDbContext.SaveChanges();
        }

        private string GetTimeDifference(DateTime date)
        {
            var dateOne = DateTime.Now;
            var dateTwo = date;
            var diff = dateTwo.Subtract(dateOne);
            var res = String.Format("{0} days {1} hours {2} minutes {3} seconds", diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
            return res;
        }
    }
}
