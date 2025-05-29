using AutoMeagler_s2_v2.EFDbContext;
using AutoMeagler_s2_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMeagler_s2_v2.Service
{
    public class DBCarService
    {
        private readonly CarDBContext _context;

        public DBCarService(CarDBContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCars()
        {
                return await _context.Cars.ToListAsync();
        }

        public async Task<List<Car>> GetBuyCars()
        {
            return await _context.Cars
                                 .Where(car => car.ForSale)
                                 .ToListAsync();
        }

        public async Task<List<Car>> GetLeasingCars()
        {
            return await _context.Cars
                                .Where(car =>! car.ForSale)
                                .ToListAsync();
        }

        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task SaveCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                _context.Cars.Add(car);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<List<Car>> SearchCarsAsync(string? searchName, string? brand, string? fuel, int? maxPrice, int? maxKm, List<string>? selectedTypes)
        {
            var query = _context.Cars.AsQueryable();

            // Start med kun biler til salg
            query = query.Where(c => c.ForSale == true);

            // Søg på model eller mærke (med null-checks)
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query = query.Where(c =>
                    (c.Model != null && c.Model.Contains(searchName)) ||
                    (c.Brand != null && c.Brand.Contains(searchName))
                );
            }

            // Filtrér mærke (null-safe)
            if (!string.IsNullOrWhiteSpace(brand))
            {
                query = query.Where(c => c.Brand != null && c.Brand == brand);
            }

            // Filtrér brændstoftype (null-safe)
            if (!string.IsNullOrWhiteSpace(fuel))
            {
                query = query.Where(c => c.Fuel != null && c.Fuel == fuel);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(c => c.Price <= maxPrice.Value);
            }

            if (maxKm.HasValue)
            {
                query = query.Where(c => c.Mileage <= maxKm.Value);
            }

            // Biltyper
            if (selectedTypes != null && selectedTypes.Any())
            {
                query = query.Where(c => c.TypeOfCar != null && selectedTypes.Contains(c.TypeOfCar));
            }

            // Hvis intet filter er valgt, returnér alle biler til salg
            bool noFilters =
                string.IsNullOrWhiteSpace(searchName) &&
                string.IsNullOrWhiteSpace(brand) &&
                string.IsNullOrWhiteSpace(fuel) &&
                (selectedTypes == null || !selectedTypes.Any()) &&
                !maxPrice.HasValue &&
                !maxKm.HasValue;

            if (noFilters)
            {
                return await _context.Cars.Where(c => c.ForSale == true).ToListAsync();
            }

            return await query.ToListAsync();
        }
    }
}
