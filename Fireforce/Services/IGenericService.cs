using Fireforce.Models;

namespace Fireforce.Services
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(T enity);
        Task ValidateEntity(T entity);
        Task UpdateAsync(T enity);
    }
}
