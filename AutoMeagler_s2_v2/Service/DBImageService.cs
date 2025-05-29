using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace AutoMeagler_s2_v2.Service
{
    public class DBImageService
    {
        private readonly ImageDBContext _context;

        public DBImageService(ImageDBContext context)
        {
            _context = context;
        }

        public void AddImage(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public void DeleteImage(int id)
        {
            var image = _context.Images.Find(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                _context.SaveChanges();
            }
        }

        public Image EditImage(Image image)
        {
            var existing = _context.Images.Find(image.Id);
            if (existing != null)
            {
                existing.ImageString = image.ImageString;
                existing.CarId = image.CarId;
                _context.SaveChanges();
            }
            return existing;
        }

        public Image GetImageById(int id)
        {
            return _context.Images.Find(id);
        }

        public List<Image> GetImages()
        {
            return _context.Images.ToList();
        }

        // 🔥 Tilføj denne metode – det er her fejlen opstår hvis den mangler
        public List<Image> GetImagesByCarId(int carId)
        {
            return _context.Images.Where(i => i.CarId == carId).ToList();
        }
    }
}
