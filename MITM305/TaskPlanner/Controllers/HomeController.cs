using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Models;
using TaskPlanner.Data.Interface;

namespace TaskPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repository;

        public HomeController(ITaskRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var taskList = _repository.GetTaskSchedule();
            return View(taskList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
