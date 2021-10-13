using Lesson1WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson1WebApplication.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index(int? id)
        {
            var model = new List<StudentViewModel>()
            {
                new StudentViewModel { ID = 1, FullName = "Lasha Tavlalashvili" } ,
                new StudentViewModel { ID = 2, FullName = "Luka Nebieridze" }
            };

            if (id.HasValue)
            {
                if(model.Any(i => i.ID == id.Value))
                   return View(model.Where(i => i.ID == id.Value));

                return View(new List<StudentViewModel>());
            }
            else
                return View(model);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            if (id == 1)
                return View(new StudentViewModel { ID = 1, FullName = "Lasha Tavlalashvili" });

            if (id == 2)
                return View(new StudentViewModel { ID = 2, FullName = "Luka Nebieridze" });
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
