using ExamManagementSystem.Domain.ViewModels;

namespace ExamManagementSystem.Application.Abstractions.Services
{
    public interface IStudentService
    {
        Task<List<StudentViewModel>> GetStudents();

        void Add(StudentViewModel student);

    }
}
