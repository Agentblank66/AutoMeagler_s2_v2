using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMeagler_s2_v2.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutoMeagler_s2_v2.Pages.Cars
{
    //[Authorize(Roles = "Employee")]
    public class DeleteCarModel : PageModel
    {
        private ICarService _CarService;

        public DeleteCarModel(ICarService carService)
        {
            _CarService = carService;
        }

        [BindProperty]
        public Models.Car Car { get; set; }


        public IActionResult OnGet(int id)
        {
            Car = _CarService.GetCar(id);
            if (Car == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Car deletedCar = _CarService.DeleteCar(Car.Id);
            if (deletedCar == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage("/Cars/AdminCar");
        }
    }
}
