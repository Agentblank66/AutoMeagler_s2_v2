using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace AutoMeagler_s2_v2.Pages.Cars
{
    public class CarModel : PageModel
    {
        private readonly ICarService _carService;
        //private readonly IWebHostEnvironment _environment;

        public Models.Car Car { get; set; }
        //public string ImagePath { get; set; }

        //[BindProperty]
        //public IFormFile CarImage { get; set; }

        // This will be bound to a hidden field or stored in Car.ImagePath for the saved image
        //[BindProperty]
        //public string UploadedImagePath { get; set; }

        //public string UploadMessage { get; set; }

        public CarModel(ICarService carService)
        {
            _carService = carService;
            //_environment = environment;
        }

        public IActionResult OnGet(int id)
        {
            Car = _carService.GetCar(id);
            if (Car == null)
                return RedirectToPage("/NotFound");

            //UploadedImagePath = Car.ImageString; // Load saved image path
            return Page();
        }

        // Upload the image and keep it ready, but don't save it to the car yet
        public async Task<IActionResult> OnPostUploadAsync(int id)
        {
            Car = _carService.GetCar(id);
            if (Car == null)
                return RedirectToPage("/NotFound");

            //if (CarImage != null && CarImage.Length > 0)
            //{
            //    var uploadsFolder = Path.Combine(_environment.WebRootPath, "car-images");
            //    if (!Directory.Exists(uploadsFolder))
            //        Directory.CreateDirectory(uploadsFolder);

            //    var fileName = Path.GetFileName(CarImage.FileName);
            //    var filePath = Path.Combine(uploadsFolder, fileName);

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await CarImage.CopyToAsync(stream);
            //    }

            //    UploadedImagePath = "/car-images/" + fileName;
            //    UploadMessage = "Billede uploadet! Husk at gemme for at bevare billedet.";

            //}
            //else
            //{
            //}

            return Page();
        }

        // Save the uploaded image path to the car permanently
        public IActionResult OnPostSaveAsync(int id)
        {
            Car = _carService.GetCar(id);
            if (Car == null)
                return RedirectToPage("/NotFound");

            //if (!string.IsNullOrEmpty(UploadedImagePath))
            //{
            //    //Car.ImageString = UploadedImagePath;

            //    _carService.UpdateCar(Car); // Make sure this updates your database

            //    UploadMessage = "Billedet er gemt!";
            //}
            //else
            //{
            //    UploadMessage = "Ingen billede at gemme.";
            //}

            return Page();
        }
    }
}