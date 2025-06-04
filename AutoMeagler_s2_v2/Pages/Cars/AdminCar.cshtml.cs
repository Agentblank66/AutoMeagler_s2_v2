using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Cars
{
    //[Authorize(Roles = "Employee")]
    public class AdminCarModel : PageModel
    {
        private readonly ICarService _carService;

        public AdminCarModel(ICarService carService)
        {
            _carService = carService;
        }

        public List<Car> Cars { get; set; } = new();

        public void OnGet()
        {
            Cars = _carService.GetCars();
        }
    }
}