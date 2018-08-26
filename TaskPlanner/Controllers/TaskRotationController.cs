using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Data.Interface;

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

        //// GET: TaskRotation/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TaskRotation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TaskRotation/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TaskRotation/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TaskRotation/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TaskRotation/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TaskRotation/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}