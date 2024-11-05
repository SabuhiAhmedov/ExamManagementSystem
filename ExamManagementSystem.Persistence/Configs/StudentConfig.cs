using ExamManagementSystem.Domain.Entities;
using ExamManagementSystem.Persistence.EntityConfigs.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamManagementSystem.Persistence.EntityConfigs
{
    public class StudentConfig : EntityBaseConfig<Student>
    {
        public virtual void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Number)
                .HasColumnName("NUMBER");

            builder.Property(x => x.Name)
                .HasColumnName("NAME");

            builder.Property(x => x.Surname)
                .HasColumnName("SURNAME");

            builder.Property(x => x.Class)
                .HasColumnName("CLASS");

            builder.ToTable("STUDENTS");
        }
    }
}
