using ExamManagementSystem.Application.Abstractions.Repositories;
using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Persistence.AppDbContext;
using ExamManagementSystem.Persistence.Repositories.Base;

namespace ExamManagementSystem.Persistence.Repositories
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(ExamsDbContext examsDbContext) : base(examsDbContext)
        {
        }
    }
}
