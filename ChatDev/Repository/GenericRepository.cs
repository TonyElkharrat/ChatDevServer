using ChatDev.Contracts;
using ChatDev.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatDev.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext chatDevDbContext)
        {
          _context = chatDevDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
           _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<bool> Exists(Guid id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(Guid? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
