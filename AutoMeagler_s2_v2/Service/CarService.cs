using AutoMeagler_s2_v2.MockData;
using AutoMeagler_s2_v2.Models;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace AutoMeagler_s2_v2.Service
{
    public class CarService: ICarService
    {
        /// <summary>
        /// List of cars in the car service.
        /// </summary>
        private List<Car> _cars;




    // ------------------------------------------------------ In test
        private DBCarService _dBCarService;

        public CarService(DBCarService dbCarService)
        {
            _dBCarService = dbCarService;
            // _items = MockItems.GetMockItems();
            //_items = _jsonFileItemService.GetJsonObjects().ToList();
            //_dbService.SaveObjects(_items);
            _cars = _dBCarService.GetCars().Result.ToList();
        }

        public CarService()
        {

        }

        // ------------------------------------------------------






        /// <summary>
        /// Methods to get all cars.
        /// </summary>
        /// <returns> A list of all cars </returns>
        public List<Car> GetCars()
        {
            return _cars;
        }

        public List<Car> GetbuyCars() 
        { 
            return _dBCarService.GetBuyCars().Result.ToList();
        }

        public List<Car> GetLeasingCars()
        {
            return _dBCarService.GetLeasingCars().Result.ToList();
        }

        /// <summary>
        /// Adds a car to the list of cars.
        /// </summary>
        /// <param name="car"></param>
        public void AddCar(Car car)
        {
            _cars.Add(car);
            _dBCarService.AddCar(car);
        }

        /// <summary>
        /// Updates a car in the list of cars.
        /// </summary>
        /// <param name="car"></param>
        public void UpdateCar(Car car)
        { 
            if (_cars != null)
            {
                foreach (Car c in _cars)
                {
                    if (c.Id == car.Id)
                    {
                        c.Id = car.Id;
                        c.TypeOfCar = car.TypeOfCar;
						c.Brand = car.Brand;
                        c.Model = car.Model;
                        c.Color = car.Color;
                        c.Fuel = car.Fuel;
                        c.ModelYear = car.ModelYear;
                        c.Price = car.Price;
                        c.Mileage = car.Mileage;
                        c.KmPrL = car.KmPrL;
                        c.TopSpeed = car.TopSpeed;
                        c.Doors = car.Doors;
                        c.HorsePower = car.HorsePower;
                        c.Gear = car.Gear;
                        c.Cylinders = car.Cylinders;                  
                        c.ZeroToOneHundred = car.ZeroToOneHundred;
                        c.Length = car.Length;
                        c.NumOffWheels = car.NumOffWheels;
                        c.MaxPull = car.MaxPull;
                        c.Weight = car.Weight;
                        c.Status = car.Status;
                        car = c;
                    }
                }
            }
            _dBCarService.UpdateCar(car);
        }

        /// <summary>
        /// Gets a car by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A car or null </returns>
        public Car? GetCar(int id)
        {
            foreach (Car car in _cars) 
            { 
                if (car.Id == id) return car;
            }
            return null;
        }

        /// <summary>
        /// Deletes a car by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> The deleted car </returns>
        public Car? DeleteCar(int id)
        {
            Car car = GetCar(id);
            _cars.Remove(GetCar(id));
            _dBCarService.DeleteCar(car);
            return car;
        }


        public async Task<List<Car>> SearchCarsAsync(string? searchName, string? brand, string? fuel, int? maxPrice, int? maxKm, List<string>? selectedTypes, bool? forSaleOnly)
        {
            var cars = await _dBCarService.SearchCarsAsync(searchName, brand, fuel, maxPrice, maxKm, selectedTypes);

            if (forSaleOnly.HasValue)
            {
                cars = cars.Where(c => c.ForSale == forSaleOnly.Value).ToList();
            }

            return cars;
        }

    }
}
