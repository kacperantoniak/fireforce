using Fireforce.Models;

namespace Fireforce.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Dept>> GetAllAsync();
    }
}
