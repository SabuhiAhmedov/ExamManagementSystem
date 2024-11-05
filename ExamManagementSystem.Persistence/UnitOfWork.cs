using ExamManagementSystem.Application.Abstractions;
using ExamManagementSystem.Application.Abstractions.Repositories;
using ExamManagementSystem.Application.Abstractions.Repositories.Base;
using ExamManagementSystem.Domain.Entities.Base;
using ExamManagementSystem.Persistence.AppDbContext;
using ExamManagementSystem.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExamManagementSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ExamsDbContext _examsDbContext;

        public UnitOfWork(ExamsDbContext examDbContext)
        {
            _examsDbContext = examDbContext;
        }


        public ILessonRepository LessonRepository { get; set; }

        public IRepository<T> Repository<T>() where T : EntityBase, IEntity
        {
            return new Repository<T>(_examsDbContext);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            ModifyContextChanges();
            await _examsDbContext.SaveChangesAsync(cancellationToken);
        }

        public void Commit()
        {
            ModifyContextChanges();
            _examsDbContext.SaveChanges();
        }


        private void ModifyContextChanges()
        {
            _examsDbContext.ChangeTracker
                .DetectChanges();

            foreach (EntityEntry entityEntry in _examsDbContext.ChangeTracker.Entries())
            {
                if (entityEntry.Entity is EntityBase entity)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            entity.RegDate = DateTime.Now;
                            entity.RegUser = "SYSTEM";
                            entity.IsActive = true;
                            break;
                        case EntityState.Modified:
                            entity.EditDate = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}
