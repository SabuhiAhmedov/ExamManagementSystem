using ExamManagementSystem.Domain.Entities.Base;

namespace ExamManagementSystem.Domain.Entities
{
    public class Lesson : EntityBase, IEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }

        public virtual List<Exam> Exams { get; set; }
    }
}
