using Fireforce.Models;
using Microsoft.EntityFrameworkCore;

namespace Fireforce.Services
{
    public class CarService : ICarService
    {
        private readonly FireforceContext _context;
        public CarService(FireforceContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Car car)
        {
            //validate
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Cars.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id) ?? throw new KeyNotFoundException($"Car with id: {id} not found");
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> UpdateAsync(Car car)
        {
            //needs checks here if dept exists, vin taken etc. but later cuz i'm tired

            var result = await _context.Cars.FirstOrDefaultAsync(x => x.Id == car.Id) ?? throw new KeyNotFoundException($"Car with id: {car.Id} not found");

            result.Brand = car.Brand;
            result.Dept = car.Dept;
            result.DeptId = car.DeptId;
            result.Model = car.Model;
            result.Notes = car.Notes;
            result.Plate = car.Plate;
            result.Vin = car.Vin;

            await _context.SaveChangesAsync();
            return result;
        }
    }
}
