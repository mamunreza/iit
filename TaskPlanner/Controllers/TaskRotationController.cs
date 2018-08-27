using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Data.Interface;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Controllers
{
    public class TaskRotationController : Controller
    {
        private readonly ITaskRotationRepository _repository;

        public TaskRotationController(ITaskRotationRepository repository)
        {
            _repository = repository;
        }

        // GET: TaskRotation
        public ActionResult Index()
        {
            return View(_repository.List());
        }

        // GET: TaskRotation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskRotation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskRotationViewModel model)
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

        // GET: TaskRotation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskRotation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskRotationViewModel model)
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
    }
}