using Microsoft.AspNetCore.Mvc;
using StudentsMVC.Models;
using StudentsMVC.Interfaces; // Importa el namespace de IStudentRepository

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository; // Cambia la inyección a IStudentRepository

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: Student
        public ActionResult Index()
        {
            var studentList = _studentRepository.GetAllStudentsAsync().Result; // Utiliza el repositorio
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
                _studentRepository.CreateStudentAsync(student); // Utiliza el repositorio
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
                var student = _studentRepository.GetStudentByIdAsync(id).Result;
        
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
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                _studentRepository.UpdateStudentAsync(id, student); // Utiliza el repositorio
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
                var student = _studentRepository.GetStudentByIdAsync(id).Result; // Utiliza el repositorio
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
                var student = _studentRepository.GetStudentByIdAsync(id).Result; // Utiliza el repositorio
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
                _studentRepository.DeleteStudentAsync(id); // Utiliza el repositorio
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
