namespace AutoMeagler_s2_v2.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageString { get; set; }
        public int CarId { get; set; }

        public string Url { get; set; } = string.Empty;
        public Car Car { get; set; }

        public Image() { }

        public Image(int id, string imageString, int carId)
        {
            Id = id;
            ImageString = imageString;
            CarId = carId;
        }
    }
}
