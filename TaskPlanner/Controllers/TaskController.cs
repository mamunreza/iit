using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TaskPlanner.Data.Interface;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repository;
        private readonly ITaskRotationRepository _taskRotationRepository;

        public TaskController(ITaskRepository repository, ITaskRotationRepository taskRotationRepository)
        {
            _repository = repository;
            _taskRotationRepository = taskRotationRepository;
        }

        // GET: Task
        public ActionResult Index()
        {
            return View(_repository.List());
        }

        //// GET: Task/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Task/Create
        public ActionResult Create()
        {
            var rotationsDb = _taskRotationRepository.List();
            var model = new TaskViewModel();
            model.ListOfTaskRotations = new SelectList(rotationsDb, "Id", "Name");
            return View(model);
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskViewModel model)
        {
            try
            {
                _repository.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            var rotationsDb = _taskRotationRepository.List();
            var taskDb = _repository.GetById(id);
            var model = new TaskViewModel
            {
                Active = taskDb.Active,
                DueDate = taskDb.DueDate,
                Id = taskDb.TaskId,
                TaskName = taskDb.TaskName,
                TaskRotationId = taskDb.TaskRotationId
            };
            model.ListOfTaskRotations = new SelectList(rotationsDb, "Id", "Name");
            return View(model);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskViewModel model)
        {
            try
            {
                _repository.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult MarkAsComplete(List<TaskScheduleViewModel> models)
        {
            try
            {
                _repository.MarkAsComplete(models);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            var taskDb = _repository.GetById(id);
            var taskRotationDb = _taskRotationRepository.GetById(taskDb.TaskRotationId);
            var model = new TaskViewModel
            {
                Active = taskDb.Active,
                DueDate = taskDb.DueDate,
                Id = taskDb.TaskId,
                TaskName = taskDb.TaskName,
                TaskRotationId = taskDb.TaskRotationId,
                TaskRotationName = taskRotationDb.Name
            };
            return View(model);
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TaskViewModel model)
        {
            try
            {
                _repository.Delete(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}