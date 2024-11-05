using ExamManagementSystem.Application.Abstractions.Services;
using ExamManagementSystem.BusinessLogic.ServiceImplementations;
using ExamManagementSystem.Domain.ViewModels;
using Logic.ServiceImplementations;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagementSystem.MVC.Controllers
{
    public class ExamController : Controller
    {
        IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        public async Task<IActionResult> Index()
        {

            _examService.Add(new ExamViewModel()
            {
                LessonCode = "1",
                StudentNumber = 223,
                ExamDate = DateTime.Now,
                Result = 100
            });

            var exams = await _examService.GetExams();

            return View();
        }

        [HttpPost]
        public IActionResult Save(ExamViewModel exam)
        {

            _examService.Add(new ExamViewModel()
            {
                LessonCode = exam.LessonCode,
                StudentNumber = exam.StudentNumber,
                ExamDate = exam.ExamDate,
                Result = exam.Result
            });

            return View();
        }

    }
}
