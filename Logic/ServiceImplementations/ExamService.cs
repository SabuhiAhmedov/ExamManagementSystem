using ExamManagementSystem.Application.Abstractions;
using ExamManagementSystem.Application.Abstractions.Services;
using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Domain.ViewModels;
using System.Data.Entity;

namespace ExamManagementSystem.BusinessLogic.ServiceImplementations
{
    public class ExamService : IExamService
    {

        IUnitOfWork _unitOfWork;
        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExamViewModel>> GetExams()
        {
            
            var exams = await _unitOfWork
                                .Repository<Exam>()
                                .AsQueryable()
                                .Include(x=>x.Lesson)
                                .Include(x=>x.Student)
                                .ToListAsync();

            List<ExamViewModel> examsViewModel = new List<ExamViewModel>();

            foreach (var exam in exams)
            {
                examsViewModel.Add(new ExamViewModel()
                {
                    ExamDate = exam.ExamDate,
                    Result  = exam.Result,  
                    LessonCode = exam.LessonCode,
                    StudentNumber   = exam.StudentNumber,
                    Lesson = new LessonViewModel()
                    {
                        Name = exam.Lesson.Name,
                        Class = exam.Lesson.Class,
                        Code = exam.Lesson.Code,
                        TeacherName = exam.Lesson.TeacherName,
                        TeacherSurname = exam.Lesson.TeacherSurname
                    },
                    Student = new StudentViewModel()
                    {
                        Name = exam.Student.Name,
                        Surname = exam.Student.Surname,
                        Class = exam.Student.Class,
                        Number = exam.Student.Number
                    }
                });
            }

            return examsViewModel;
            
        }

        public void Add(ExamViewModel exam)
        {
            _unitOfWork.Repository<Exam>().Add(new Exam()
            {
                ExamDate = exam.ExamDate,
                Result = exam.Result,
                LessonCode = exam.LessonCode,
                StudentNumber = exam.StudentNumber,
            });

            _unitOfWork.Commit();
        }
    }
}
