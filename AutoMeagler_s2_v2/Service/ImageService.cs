using AutoMeagler_s2_v2.Models;

namespace AutoMeagler_s2_v2.Service
{
    public class ImageService : IImageService
    {
        private readonly DBImageService _dbImageService;

        public ImageService(DBImageService dbImageService)
        {
            _dbImageService = dbImageService;
        }

        public void AddImage(Image image)
        {
            // Her kan du validere billedet fx:
            if (string.IsNullOrEmpty(image.ImageString))
                throw new ArgumentException("Image string cannot be empty");

            _dbImageService.AddImage(image);
        }

        public void DeleteImage(int id)
        {
            _dbImageService.DeleteImage(id);
        }

        public Image EditImage(Image image)
        {
            return _dbImageService.EditImage(image);
        }

        public Image GetImageById(int id)
        {
            return _dbImageService.GetImageById(id);
        }

        public List<Image> GetImages()
        {
            return _dbImageService.GetImages();
        }

        public List<Image> GetImagesByCarId(int carId)
        {
            return _dbImageService.GetImagesByCarId(carId);
        }
    }
}
