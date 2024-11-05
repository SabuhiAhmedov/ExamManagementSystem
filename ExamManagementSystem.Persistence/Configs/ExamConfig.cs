using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Persistence.EntityConfigs.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamManagementSystem.Persistence.EntityConfigs
{
    public class ExamConfig : EntityBaseConfig<Exam>
    {
        public virtual void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.LessonCode)
                .HasColumnName("LESSON_CODE");

            builder.Property(x => x.StudentNumber)
                .HasColumnName("STUDENT_NUMBER");

            builder.Property(x => x.ExamDate)
                .HasColumnName("EXAM_DATE");

            builder.Property(x => x.Result)
                .HasColumnName("RESULT");

            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.Exams)
                .HasForeignKey(x => x.LessonCode);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Exams)
                .HasForeignKey(x => x.StudentNumber);

            builder.ToTable("EXAMS");
        }
    }
}
