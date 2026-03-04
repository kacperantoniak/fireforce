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
            //business logic here- validate data
            //add valid voivodeship names to database and check if given voivodeship matches with database
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

        public Task<Dept> UpdateAsync(Dept enity)
        {
            throw new NotImplementedException();
        }
    }
}
