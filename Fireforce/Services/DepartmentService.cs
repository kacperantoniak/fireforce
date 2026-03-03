using Fireforce.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task AddAsync(Dept dept)
        {
            await _context.Depts.AddAsync(dept);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Depts.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Dept>> GetAllAsync()
        {
            return await _context.Depts.ToListAsync();
        }

        public async Task<Dept> GetByIdAsync(int id)
        {
            //if result == null throw exception, else return result
            return await _context.Depts.FindAsync(id) ?? throw new KeyNotFoundException($"Depratment with id: {id} not found");
        }
    }
}
