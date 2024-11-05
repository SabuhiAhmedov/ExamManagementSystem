using ExamManagementSystem.Application.Abstractions.Services;
using ExamManagementSystem.BusinessLogic.ServiceImplementations;
using ExamManagementSystem.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagementSystem.MVC.Controllers
{
    public class LessonController : Controller
    {

        ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        
        public async Task<IActionResult> Index()
        {

            _lessonService.Add(new LessonViewModel()
            {
                Code = "2",
                Name = "Math",
                Class = 10,
                TeacherName = "Sabuhi",
                TeacherSurname = "Ahmed"
            });

            var lessons = await _lessonService.GetLessons();

            return View();
        }

        [HttpPost]
        public IActionResult Save(LessonViewModel lesson)
        {

            _lessonService.Add(new LessonViewModel()
            {
                Code = lesson.Code,
                Name = lesson.Name,
                Class = lesson.Class,
                TeacherName = lesson.TeacherName,
                TeacherSurname = lesson.TeacherSurname
            });

            return View();
        }
    }
}
