using ExamManagementSystem.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamManagementSystem.Persistence.EntityConfigs.Base
{
    public abstract class EntityBaseConfig<TEntity> : IEntityTypeConfiguration<TEntity>
          where TEntity : EntityBase, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID");

            builder.Property(x => x.RegUser)
                .HasColumnName("REG_USER");

            builder.Property(x => x.RegDate)
                .HasColumnName("REG_DATE");

            builder.Property(x => x.EditUser)
                .HasColumnName("EDIT_USER");

            builder.Property(x => x.EditDate)
                .HasColumnName("EDIT_DATE");

            builder.Property(x => x.IsActive)
                .HasColumnName("IS_ACTIVE");
        }
    }
}
