namespace ExamManagementSystem.Domain.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime? RegDate { get; set; }
        public string? RegUser { get; set; }
        public DateTime? EditDate { get; set; }
        public string? EditUser { get; set; }
        public bool IsActive { get; set; }
    }
}
