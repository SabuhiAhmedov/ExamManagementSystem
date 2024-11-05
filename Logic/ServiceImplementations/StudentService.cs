using ExamManagementSystem.Application.Abstractions;
using ExamManagementSystem.Application.Abstractions.Services;
using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Domain.ViewModels;
using System.Data.Entity;

namespace ExamManagementSystem.BusinessLogic.ServiceImplementations
{
    public class StudentService : IStudentService
    {
        IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StudentViewModel>> GetStudents()
        {
            var students = await _unitOfWork.Repository<Student>().GetAllAsync();

            List<StudentViewModel> studentsViewModel = new List<StudentViewModel>();

            foreach (var student in students)
            {
                studentsViewModel.Add(new StudentViewModel()
                {
                    Name = student.Name,
                    Surname = student.Surname,
                    Class = student.Class,
                    Number = student.Number
                });
            }

            return studentsViewModel;
        }

        public void Add(StudentViewModel student)
        {
            _unitOfWork.Repository<Student>().Add(new Student()
            {
                Name = student.Name,
                Surname = student.Surname,
                Class = student.Class,
                Number = student.Number
            });

            _unitOfWork.Commit();
        }
    }
}
