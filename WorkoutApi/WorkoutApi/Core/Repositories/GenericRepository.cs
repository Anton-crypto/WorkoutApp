using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkoutApi.Core.IRepositories;
using WorkoutApi.Data;

namespace WorkoutApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _context;
        protected readonly ILogger _logger;
        protected DbSet<T> dbSet;

        public GenericRepository(
            AppDbContext context,
            ILogger logger    
        )
        {
            _context = context;
            _logger = logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
