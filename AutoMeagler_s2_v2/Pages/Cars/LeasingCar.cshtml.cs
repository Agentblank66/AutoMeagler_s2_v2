using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Cars
{
    public class LeaseModel : PageModel
    {

        private ICarService _carService;
        //private IImageService _imageService;

        public LeaseModel(ICarService carService)
        {
            _carService = carService;
            //_imageService = imageService;
        }


        //public List<Models.Car> Cars { get; private set; } = new List<Models.Car>()
        //{
        //       new Cars { Brand = "BMW", Model = "320i", MonthlyPrice = 4500, Months = 36, Year = 2022, KmIncluded = 15000 },
        //       new Cars { Brand = "Audi", Model = "A4", MonthlyPrice = 4200, Months = 24, Year = 2021, KmIncluded = 20000 },
        //       new Cars { Brand = "Mercedes", Model = "C200", MonthlyPrice = 4800, Months = 36, Year = 2023, KmIncluded = 18000 }
        //};

        public List<Models.Car> Cars { get; private set; } = new List<Models.Car>() { };
        //public List<Image> Images { get; private set; }


        public void OnGet()
        {
            Cars = _carService.GetLeasingCars();
            //Images = _imageService.GetImages();
        }

    }
}
