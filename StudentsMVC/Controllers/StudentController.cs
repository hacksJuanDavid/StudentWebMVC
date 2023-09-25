using Microsoft.AspNetCore.Mvc;
using StudentsMVC.Models;
using StudentsMVC.Services; 

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService; // Cambia la inyección a la interfaz IStudentService

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Student
        public ActionResult Index()
        {
            var studentList = _studentService.GetAllStudentsAsync().Result; // Utiliza el IStudentService
            return View(studentList);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student? student)
        {
            try
            {
                _studentService.CreateStudentAsync(student); // Utiliza el IStudentService
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var student = _studentService.GetStudentByIdAsync(id).Result;

                if (student == null)
                {
                    return NotFound(); // Retorna una respuesta 404 si el estudiante no se encuentra
                }

                return View(student);
            }
            catch
            {
                return View();
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student? student)
        {
            try
            {
                _studentService.UpdateStudentAsync(id, student); // Utiliza el IStudentService
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var student = _studentService.GetStudentByIdAsync(id).Result; // Utiliza el IStudentService
                return View(student);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var student = _studentService.GetStudentByIdAsync(id).Result; // Utiliza el IStudentService
                return View(student);
            }
            catch
            {
                return View();
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                _studentService.DeleteStudentAsync(id); // Utiliza el IStudentService
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult StudentEdit()
        {
            throw new NotImplementedException();
        }
    }
}