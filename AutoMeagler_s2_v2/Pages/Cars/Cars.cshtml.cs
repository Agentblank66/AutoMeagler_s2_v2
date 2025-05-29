using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace AutoMeagler_s2_v2.Pages.Cars
{
    public class CarsModel : PageModel
    {
        private ICarService _carService;

        public CarsModel(ICarService carService)
        {
            _carService = carService;
        }

        public List<Models.Car> Cars { get; private set; } = new List<Models.Car>() { };
        public List<SelectListItem> BrandOptions { get; set; }
        public List<SelectListItem> FuelOptions { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public List<string> SelectedTypes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Brand { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Fuel { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PriceMax { get; set; } = 1000000;

        [BindProperty(SupportsGet = true)]
        public int KmMax { get; set; } = 500000;


        public async Task OnGetAsync()
        {
            SelectedTypes ??= new List<string>();

            BrandOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- Vælg mærke --" },
                new SelectListItem { Value = "Audi", Text = "Audi" },
                new SelectListItem { Value = "BMW", Text = "BMW" },
                new SelectListItem { Value = "Ford", Text = "Ford" },
                new SelectListItem { Value = "Toyota", Text = "Toyota" },
                new SelectListItem { Value = "Tesla", Text = "Tesla" }
            };

            FuelOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- Vælg brændstof --" },
                new SelectListItem { Value = "Benzin", Text = "Benzin" },
                new SelectListItem { Value = "Diesel", Text = "Diesel" },
                new SelectListItem { Value = "Hybrid", Text = "Hybrid" },
                new SelectListItem { Value = "ElBil", Text = "ElBil" }
            };

            Cars = (await _carService.SearchCarsAsync(SearchName, Brand, Fuel, PriceMax, KmMax, SelectedTypes, true)).ToList();
        }
    }
}
