using ExamManagementSystem.Application.Abstractions.Services;
using ExamManagementSystem.BusinessLogic.ServiceImplementations;
using ExamManagementSystem.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagementSystem.MVC.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {

            var students = await _studentService.GetStudents();

            return View();
        }

        [HttpPost]
        public IActionResult Save(StudentViewModel student)
        {

            _studentService.Add(new StudentViewModel()
            {
                Name = student.Name,
                Surname = student.Surname,
                Number = student.Number,
                Class = student.Class
            });

            return View();
        }

    }


}

