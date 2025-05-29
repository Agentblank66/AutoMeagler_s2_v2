using System.ComponentModel.DataAnnotations;

namespace AutoMeagler_s2_v2.Models
{
    public class Customer: User
    {
        /// <summary>
        /// Properties of the Customer class.
        /// </summary>
        [Display(Name = "Bruger ønsker at sælge?")]
        [Required(ErrorMessage = "Der skal angives om Brugeren ønsker at sælge.")]
        public bool WishToSell { get; set; }
        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Der skal angives et Bruger Telefonnummer.")]
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Constructor which initializes the customer with default values.
        /// </summary>
        public Customer() : base(0, "", "", "", "")
        {
           
        }

        /// <summary>
        /// Constructor which initializes the customer with the given parameters, aswell as the users given parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phonenumber"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="wishtosell"></param>
        public Customer(int id, string firstName,string lastName, int phonenumber, string email, string password, bool wishtosell): base(id, firstName, lastName, email, password)
        {
            UserTypes = UserType.Customer;

            WishToSell = wishtosell;
            PhoneNumber = phonenumber;
        }

        /// <summary>
        /// A method which overrides the ToString method to return the customer properties.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id} Fullname: {FullName} PhoneNumber: {PhoneNumber} Email: {Email} WishToSell: {WishToSell}";
        }
    }
}
