using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Cars
{
    public class addImageModel : PageModel
    {

        private readonly ICarService _carService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _environment;


        public addImageModel(ICarService carService, IImageService imageService, IWebHostEnvironment environment)
        {
            _carService = carService;
            _imageService = imageService;
            _environment = environment;
        }


        [BindProperty]
        public Car Car { get; set; }

        [BindProperty]
        public IFormFile CarImage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CarId { get; set; }




        public IActionResult OnGet(int id)
        {
            Car = _carService.GetCar(id);
            CarId = id;
            if (Car == null)
                return RedirectToPage("/index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (CarImage == null || CarImage.Length == 0)
            {
                return Page();
            }

            // Du kan ændre stien til noget mere sikkert (f.eks. i wwwroot/images/)
            var uploadsFolder = Path.Combine("wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = $"car_{CarId}_{Path.GetFileName(CarImage.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await CarImage.CopyToAsync(stream);
            }


            Image image = new Image
            {
                ImageString = "/uploads/" + fileName, // Gem stien til billedet
                CarId = CarId


            };

            _imageService.AddImage(image);
            return RedirectToPage("/Cars/admincar");
        }
    }
}
