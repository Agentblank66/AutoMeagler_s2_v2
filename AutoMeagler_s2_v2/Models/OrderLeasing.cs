using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace AutoMeagler_s2_v2.Models
{
    public class OrderLeasing : Order
    {
        /// <summary>
        /// Properties of the OrderLeasing class.
        /// </summary>
        [Display(Name = "Depositum")]
        [Required(ErrorMessage = "Der skal være et depositum tilknyttet ordren")]
        [Range(typeof(double), "0", "100000", ErrorMessage = "Depositum skal være mellem (1) og (2)")]
        public double Depositum { get; set; }

        [Display(Name = "Leasing dato start")]
        [Required(ErrorMessage = "Der skal være en start leasing dato tilknyttet ordren")]
        public DateTime LeasingDateStart { get; set; }

        [Display(Name = "Leasing dato slut")]
        [Required(ErrorMessage = "Der skal være en slut leasing dato tilknyttet ordren")]
        public DateTime LeasingDateEnd { get; set; }

        [Display(Name = "Start år")]
        [Required(ErrorMessage = "Der skal være et år")]
        [Range(typeof(int),"2025","9999", ErrorMessage = "År skal være mellem (1) og (2)")]
        public int StartYear { get; set; }

        [Display(Name = "Afleverings år")]
        [Required(ErrorMessage = "Der skal være et år")]
        [Range(typeof(int), "2025", "9999", ErrorMessage = "År skal være mellem (1) og (2)")]
        public int EndYear { get; set; }

        [Display(Name = "Start måned")]
        [Required(ErrorMessage = "Der skal være et måned")]
        [Range(typeof(int), "1", "12", ErrorMessage = "Måned skal være mellem (1) og (2)")]
        public int StartMonth { get; set; }

        [Display(Name = "Afleverings måned")]
        [Required(ErrorMessage = "Der skal være et måned")]
        [Range(typeof(int), "1", "12", ErrorMessage = "Måned skal være mellem (1) og (2)")]
        public int EndMonth { get; set; }

        [Display(Name = "Start dag")]
        [Required(ErrorMessage = "Der skal være et dag")]
        [Range(typeof(int), "1", "31", ErrorMessage = "Måned skal være mellem (1) og (2)")]
        public int StartDay { get; set; }

        [Display(Name = "Afleverings dag")]
        [Required(ErrorMessage = "Der skal være et dag")]
        [Range(typeof(int), "1", "31", ErrorMessage = "Måned skal være mellem (1) og (2)")]
        public int EndDay { get; set; }

        [Display(Name = "Månedlig betaling")]
        [Required(ErrorMessage = "Der skal være en månedlig betaling tilknyttet ordren")]
        [Range(typeof(double), "0", "100000", ErrorMessage = "Månedlig betaling skal være mellem (1) og (2)")]
        public double MonthlyPayment { get; set; }

        /// <summary>
        /// Constructor for the OrderLeasing class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="employee"></param>
        /// <param name="customer"></param>
        /// <param name="type"></param>
        /// <param name="dipositum"></param>
        /// <param name="leasingDateStart"></param>
        /// <param name="monthlyPayment"></param>
        public OrderLeasing(int id, Car car, Employee employee, Customer customer, OrderType type, double dipositum, int startYear, int endYear, int startMonth, int endMonth, int startDay, int endDay, double monthlyPayment)
            : base(id, car, employee, customer, type)
        {
            Depositum = dipositum;
            LeasingDateStart = new DateTime(startYear, startMonth, startDay);
            MonthlyPayment = monthlyPayment;
            LeasingDateEnd = new DateTime(endYear, endMonth, endDay);
        }

        /// <summary>
        /// Default constructor for the OrderLeasing class, initializing with default values.
        /// </summary>
        public OrderLeasing() : base(0,new Car(), new Employee(), new Customer(), OrderType.Leasing) 
        {
            Depositum = 0.0;
            LeasingDateStart = DateTime.Now;
            LeasingDateEnd = DateTime.Now.AddYears(1);
            MonthlyPayment = 0.0;
            StartYear = DateTime.Now.Year;
            EndYear = DateTime.Now.Year + 1;
            StartMonth = DateTime.Now.Month;
            EndMonth = DateTime.Now.Month + 1;
            StartDay = DateTime.Now.Day;
            EndDay = DateTime.Now.Day;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the OrderLeasing object.
        /// </summary>
        /// <returns> A string with properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer} Type: {Type} Depositum: {Depositum} LeasingDateStart: {LeasingDateStart} LeasingDateEnd: {LeasingDateEnd} MonthlyPayment: {MonthlyPayment}";
        }
    }
}
