using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Persistence.EntityConfigs.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamManagementSystem.Persistence.EntityConfigs
{
    public class LessonConfig : EntityBaseConfig<Lesson>
    {
        public virtual void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(x => x.Code)
                .HasColumnName("CODE");

            builder.Property(x => x.Name)
                .HasColumnName("NAME");

            builder.Property(x => x.Class)
                .HasColumnName("CLASS");

            builder.Property(x => x.TeacherName)
                .HasColumnName("TEACHER_NAME");

            builder.Property(x => x.TeacherSurname)
                .HasColumnName("TEACHER_SURNAME");

            builder.ToTable("LESSONS");
        }
    }
}
