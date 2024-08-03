using ExaminantionSystem.API.Data;
using ExaminantionSystem.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminantionSystem.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> GetAllAsync()
            =>  _context.Set<T>().AsNoTracking();


        public async Task<T> GetAsync(int Id)
         => await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);


        public async Task<T> AddAsync(T item)
        {
           await  _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }      

        public async Task UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Set<T>().Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public Task<bool> IsTEntityExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AnyAsync(expression);
        }
  
        public async Task<int> SaveChangesAsync()
        {
            return  await _context.SaveChangesAsync();
        }

        public Task<T> GetWithCriteriaAsync(Expression<Func<T, bool>> expression)
        {
            var cirteria = _context.Set<T>().FirstOrDefaultAsync(expression);

            return cirteria;
        }
    }
}
