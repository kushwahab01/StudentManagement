using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;
        StudentDAL studentDAL;
        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
            studentDAL=new StudentDAL(this.db);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var list=studentDAL.GetAllStudents();
            ViewBag.Students = new SelectList(db.students,"id","Title");
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var stud=studentDAL.GetStudentById(id);
            return View(stud);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stud)
        {
            try
            {
                int result = studentDAL.AddStudent(stud);
                if (result == 1)

                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var stud=studentDAL.GetStudentById(id);
            return View(stud);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stud)
        {
            try
            {
                int result = studentDAL.UpdateStudent(stud);
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var stud=studentDAL.GetStudentById(id);
            return View(stud);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int result=studentDAL.DeleteStudent(id);    
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                var allStudents = studentDAL.GetAllStudents(); // Replace with actual logic to get all students
                return View("Index", allStudents);
            }
            else
            {
                var searchResults = studentDAL.SearchStudents(searchString); // Replace with actual search logic
                return View("Index", searchResults);
            }
        }


    }
}
