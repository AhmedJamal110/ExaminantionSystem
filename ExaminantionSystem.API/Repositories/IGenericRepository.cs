using ExaminantionSystem.API.Entities;
using System.Linq.Expressions;

namespace ExaminantionSystem.API.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetAsync(int Id);
        Task<T> GetWithCriteriaAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T item);
        Task UpdateAsync(T item);
        Task<bool> IsTEntityExist(Expression<Func<T, bool>> expression);
        Task DeleteAsync(int id);
        public Task<int> SaveChangesAsync();
    }
}
