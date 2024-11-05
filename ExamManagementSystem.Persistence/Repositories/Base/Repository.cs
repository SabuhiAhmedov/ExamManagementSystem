using ExamManagementSystem.Application.Abstractions.Repositories.Base;
using ExamManagementSystem.Domain.Entities.Base;
using ExamManagementSystem.Persistence.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace ExamManagementSystem.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : EntityBase, IEntity
    {
        protected readonly ExamsDbContext _examsDbContext;

        public Repository(ExamsDbContext examsDbContext)
        {
            _examsDbContext = examsDbContext;
        }


        public void Delete(T entity)
        {
            _examsDbContext.Remove(entity);
        }

        public  IList<T> GetAll()
        {
            return  _examsDbContext.Set<T>().ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _examsDbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _examsDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public void Update(T entity)
        {
            _examsDbContext.Update(entity);
        }

        public void Add(T entity)
        {
            _examsDbContext.Add(entity);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return  _examsDbContext.Set<T>().FirstOrDefault(expression);
        }

        public IQueryable<T> AsQueryable()
        {
            return _examsDbContext.Set<T>();
        }
    }

}
