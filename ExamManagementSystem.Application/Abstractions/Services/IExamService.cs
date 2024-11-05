using ExamManagementSystem.Domain.ViewModels;

namespace ExamManagementSystem.Application.Abstractions.Services
{
    public interface IExamService
    {
        Task<List<ExamViewModel>> GetExams();

        void Add(ExamViewModel exam);

    }
}
