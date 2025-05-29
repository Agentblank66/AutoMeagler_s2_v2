using AutoMeagler_s2_v2.Models;

namespace AutoMeagler_s2_v2.Service
{
    public interface ICarService
    {
        /// <summary>
        /// Methods that any class implementing this interface must implement.
        /// </summary>
        public List<Car> GetCars();
        public List<Car> GetbuyCars();
        public List<Car> GetLeasingCars();
        public void AddCar(Car car);
        public void UpdateCar(Car car);
        public Car GetCar(int id);
        public Car DeleteCar(int id);
        public Task<List<Car>> SearchCarsAsync(string? searchTerm, string? brand, string? fuel, int? maxPrice, int? maxKm, List<string>? selectedTypes, bool? forSaleOnly);

    }
}
