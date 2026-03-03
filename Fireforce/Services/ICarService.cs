using Fireforce.Models;

namespace Fireforce.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Car car);
        Task<Car> UpdateAsync(Car car);
    }
}
