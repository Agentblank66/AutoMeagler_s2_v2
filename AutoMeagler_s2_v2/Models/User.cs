using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMeagler_s2_v2.Models
{
    public abstract class User
    {
        /// <summary>
        /// Enumeration for User types.
        /// </summary>
        public enum UserType
        {
            [Display(Name = "Kunde")]
            Customer,
            [Display(Name = "Medarbejder")]
            Employee,
        }
        /// <summary>
        /// Properties of the User class.
        /// </summary>
        [NotMapped]
        public UserType UserTypes { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Der skal angives et Bruger Id.")]
        public int Id { get; set; }
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Der skal angives et Fornavn."), MaxLength(100)]
        public string FirstName { get; set; }
        [Display(Name = "Efternavn")]
        [Required(ErrorMessage = "Der skal angives et Efternavn."), MaxLength(100)]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Der skal angives et Bruger Email.")]
        [StringLength(100, ErrorMessage = "Email længden kan ikke være mere end 100 ord.")]
        public string Email { get; set; }
        [Display(Name = "Adgangskode")]
        [Required(ErrorMessage = "Der skal angives et Bruger Adgangskode")]
        public string Password { get; set; }

        /// <summary>
        /// A constructor which initializes the user with the given parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public User(int id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            
        }
    }
}
