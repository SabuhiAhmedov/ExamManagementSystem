using ExamManagementSystem.Domain.Entities.Base;

namespace ExamManagementSystem.Domain.Entities
{
    public class Exam : EntityBase, IEntity
    {
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int Result { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
    }
}
