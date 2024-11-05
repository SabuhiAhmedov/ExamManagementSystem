using ExamManagementSystem.Domain.Entities.Base;

namespace ExamManagementSystem.Domain.Entities
{
    public class Student : EntityBase, IEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }

        public virtual List<Exam> Exams { get; set; }
    }
}
