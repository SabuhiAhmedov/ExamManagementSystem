
using ExamManagementSystem.Domain.Entities.Base;
using System.Linq.Expressions;

namespace ExamManagementSystem.Application.Abstractions.Repositories.Base
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FirstOrDefault(Expression<Func<T, bool>> func);
        Task<IList<T>> GetAllAsync();
        IList<T> GetAll();

        IQueryable<T> AsQueryable();
        
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
