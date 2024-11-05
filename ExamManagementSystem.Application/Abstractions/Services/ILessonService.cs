using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Domain.ViewModels;

namespace ExamManagementSystem.Application.Abstractions.Services
{
    public interface ILessonService
    {
        Task<List<LessonViewModel>> GetLessons();

        void Add(LessonViewModel lesson);

    }
}
