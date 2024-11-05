using ExamManagementSystem.Domain.Entities;

namespace ExamManagementSystem.Domain.ViewModels
{
    public class ExamViewModel
    {
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int Result { get; set; }

        public LessonViewModel Lesson { get; set; }
        public StudentViewModel Student { get; set; }
    }
}
