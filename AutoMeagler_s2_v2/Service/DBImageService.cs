using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace AutoMeagler_s2_v2.Service
{
    public class DBImageService
    {
        private readonly DBContext _context;

        public DBImageService(DBContext context)
        {
            _context = context;
        }

        public void AddImage(Image image)
        {
            _context.Image.Add(image);
            _context.SaveChanges();
        }

        public void DeleteImage(int id)
        {
            var image = _context.Image.Find(id);
            if (image != null)
            {
                _context.Image.Remove(image);
                _context.SaveChanges();
            }
        }

        public Image EditImage(Image image)
        {
            var existing = _context.Image.Find(image.Id);
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
            return _context.Image.FirstOrDefault(i => i.CarId == id);
        }

        public List<Image> GetImages()
        {
            return _context.Image.ToList();
        }

        // 🔥 Tilføj denne metode – det er her fejlen opstår hvis den mangler
        public List<Image> GetImagesByCarId(int carId)
        {
            return _context.Image.Where(i => i.CarId == carId).ToList();
        }
    }
}
