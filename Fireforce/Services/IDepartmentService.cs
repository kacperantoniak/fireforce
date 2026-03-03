using Fireforce.Models;

namespace Fireforce.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Dept>> GetAllAsync();
        Task<Dept> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Dept dept);
    }
}
