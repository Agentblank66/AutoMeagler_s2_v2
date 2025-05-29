using System.ComponentModel.DataAnnotations;

namespace AutoMeagler_s2_v2.Models
{
    public class Employee: User
    {
        /// <summary>
        /// Properties of the Employee class.
        /// </summary>
        [Display(Name = "Type")]
        [Required(ErrorMessage = "Der skal angives en Bruger Type.")]
        public string Type { get; set; }

        /// <summary>
        /// Constructor for the Employee class with default values.
        /// </summary>
        public Employee(): base(0, "", "", "", "")
        {

        }

        /// <summary>
        /// Constructor for the Employee class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="type"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Employee(int id, string firstName, string lastName, string type, string email, string password): base(id, firstName, lastName, email, password)
        {
            UserTypes = UserType.Employee;
            Type = type;
           
        }

        

        /// <summary>
        /// Overrides the ToString method to return a string representation of the Employee object.
        /// </summary>
        /// <returns> A string with properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Fullname: {FullName} Type: {Type} Email: {Email}";
        }
    }
}
