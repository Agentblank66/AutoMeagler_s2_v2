namespace AutoMeagler_s2_v2.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageString { get; set; }
        public int CarId { get; set; }

        public Image() { }

        public Image( string imageString, int carId)
        {
            
            ImageString = imageString;
            CarId = carId;
        }
    }
}
