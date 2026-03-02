using Fireforce.Models;
using Microsoft.EntityFrameworkCore;

namespace Fireforce.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly FireforceContext _context;

        public DepartmentService(FireforceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dept>> GetAllAsync()
        {
            return await _context.Depts.ToListAsync();
        }
    }
}
