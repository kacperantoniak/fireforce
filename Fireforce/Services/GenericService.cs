using Fireforce.Models;
using Microsoft.EntityFrameworkCore;

namespace Fireforce.Services
{
    public class GenericService<T> : IGenericService<T>
        where T : class
    {
        protected readonly FireforceContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericService(FireforceContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet
                .FindAsync(id) ?? throw new KeyNotFoundException($"{_dbSet.EntityType} with id: {id} not found.");
        }


        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await ValidateEntity(entity);

            var property = typeof(T)
                .GetProperty("Id") ?? throw new KeyNotFoundException($"Entity {_dbSet.EntityType} has no Id property.");

            var id = property
                .GetValue(entity) ?? throw new KeyNotFoundException("Id cannot be null");

            T result = await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"{_dbSet.EntityType} was just probaly deleted by someone else.");

            _context.Entry(result)
                .CurrentValues
                .SetValues(entity);

            await _context.SaveChangesAsync();
        }

        //this method can be overriden in derived class to validate data before calling an update to database
        public virtual async Task ValidateEntity(T entity)
        { 
            throw new NotImplementedException();
        }
    }
}
