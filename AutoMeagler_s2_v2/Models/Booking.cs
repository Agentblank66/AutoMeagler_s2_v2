namespace AutoMeagler_s2_v2.Models
{
    public class Booking
    {
        /// <summary>
        /// Properties of the Booking class.
        /// </summary>
        public int Id { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Constructor for the Booking class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="customer"></param>
        /// <param name="date"></param>
        public Booking(int id, Car car, Customer customer, DateTime date)
        {
            Id = id;
            Car = car;
            Customer = customer;
            Date = date;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the Booking object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Customer: {Customer} Date: {Date}";
        }
    }

}
