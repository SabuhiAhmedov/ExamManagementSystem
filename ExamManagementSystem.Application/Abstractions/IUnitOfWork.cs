using ExamManagementSystem.Application.Abstractions.Repositories;
using ExamManagementSystem.Application.Abstractions.Repositories.Base;
using ExamManagementSystem.Domain.Entities.Base;

namespace ExamManagementSystem.Application.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : EntityBase, IEntity;

        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
