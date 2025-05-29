using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Cars
{
    public class CreateCarModel : PageModel
    {
		private readonly ICarService _carService;
		//private readonly IWebHostEnvironment _environment;
		//private readonly IImageService _imageService;

		public CreateCarModel(ICarService carService)
        {
			_carService = carService;
			//_environment = environment;
			//_imageService = imageService;
        }

        [BindProperty]
        public AutoMeagler_s2_v2.Models.Car Car { get; set; }
        //public List<String> ImageString { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _carService.AddCar(Car);
            return RedirectToPage("/Cars/Cars");
        }


        //public string ImagePath { get; set; }


        //[BindProperty]
        //public IFormFile CarImage { get; set; }

        // This will be bound to a hidden field or stored in Car.ImagePath for the saved image
        //[BindProperty]
        //public string UploadedImagePath { get; set; }

        //public string UploadMessage { get; set; }


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
            //    UploadMessage = "Vælg et gyldigt billede.";
            //}

            return Page();
        }

        // Save the uploaded image path to the car permanently
        public IActionResult OnPostSaveAsync(int id, Image image)
        {
            Car = _carService.GetCar(id);
            if (Car == null)
                return RedirectToPage("/NotFound");

            ////if (!string.IsNullOrEmpty(UploadedImagePath))
            ////{
            ////    image.ImageString = UploadedImagePath;

            ////    //Car.ImageString = UploadedImagePath;

            ////    _imageService.AddImage(image); // Make sure this updates your database

            ////    UploadMessage = "Billedet er gemt!";
            ////}
            ////else
            ////{
            ////    UploadMessage = "Ingen billede at gemme.";
            ////}

            return Page();
        }

    }
}
