using System.ComponentModel.DataAnnotations;

namespace AutoMeagler_s2_v2.Models
{
    public class OrderSale : Order
    {
        /// <summary>
        /// Properties of the OrderSale class.
        /// </summary>

        [Display(Name = "Salgs Pris")]
        [Required(ErrorMessage = "Der skal være en salgs pris tilknyttet ordren")]
        [Range(typeof(double), "0", "10000000", ErrorMessage = "Salgs pris skal være mellem (1) og (2)")]
        public double SalePrice { get; set; }

        [Display(Name = "Salgs Dato")]
        [Required(ErrorMessage = "Der skal være en salgs dato tilknyttet ordren")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "År")]
        [Required(ErrorMessage = "Der skal være et år")]
        public int Year { get; set; }

        [Display(Name = "Måned")]
        [Required(ErrorMessage = "Der skal være et måned")]
        public int Month { get; set; }

        [Display(Name = "Dag")]
        [Required(ErrorMessage = "Der skal være et dag")]
        public int Day { get; set; }

        /// <summary>
        /// Constructor for the OrderSale class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="employee"></param>
        /// <param name="customer"></param>
        /// <param name="type"></param>
        /// <param name="salePrice"></param>
        /// <param name="saleDate"></param>
        public OrderSale(int id, Car car, Employee employee, Customer customer, OrderType type, double salePrice, int year, int month, int day)
            : base(id, car, employee, customer, type)
        {
            SalePrice = salePrice;
            SaleDate = new DateTime(year, month, day);
        }

        /// <summary>
        /// Default constructor for the OrderSale class, initializing with default values.
        /// </summary>
        public OrderSale() : base(0,new Car(), new Employee() , new Customer() ,OrderType.Sale ) 
        {
            SalePrice = 0.0;
            SaleDate = DateTime.Now;
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            Day = DateTime.Now.Day;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the OrderSale object.
        /// </summary>
        /// <returns> A string with the properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer} Type: {Type} SalePrice: {SalePrice} SaleDate: {SaleDate}";
        }
    }
}
