using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace AutoMeagler_s2_v2.Models
{
    public abstract class Order: IComparable<Order>
    {
        /// <summary>
        /// Represents the type of order.
        /// </summary>
        public enum OrderType
        {
            Leasing,
            Buy,
            Sale
        }

        /// <summary>
        /// Properties of the Order class.
        /// </summary>

        [Display(Name = "Type of order")]
        [Required(ErrorMessage = "Order skal have en type")]
        public OrderType Type { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "En bil")]
        [Required(ErrorMessage = "Der skal være en bil tilknyttet ordren")]
        public Car Car { get; set; }

        [Display(Name = "En medarbejder")]
        [Required(ErrorMessage = "Der skal være en medarbejder tilknyttet ordren")]
        public Employee Employee { get; set; }

        [Display(Name = "En kunde")]
        [Required(ErrorMessage = "Der skal være en kunde tilknyttet ordren")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Constructor for the Order class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="employee"></param>
        /// <param name="customer"></param>
        /// <param name="type"></param>
        public Order(int id, Car car, Employee employee, Customer customer, OrderType type)
        {
            Id = id;
            Car = car;
            Employee = employee;
            Customer = customer;
            Type = type;
        }

        /// <summary>
        /// A method that compares two orders.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Order other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
