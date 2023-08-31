using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentsListController : Controller
    {
        // GET: StudentsListController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentsListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentsListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentsListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentsListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
