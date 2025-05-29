using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static AutoMeagler_s2_v2.Models.User;


namespace AutoMeagler_s2_v2.Pages.Admin
{
    [Authorize(Roles = "Employee")]
    public class CreateUserModel : PageModel
    {
        /// <summary>
        ///  Properties of the CreateUserModel class.
        /// </summary>
        private UserService _userService;
        private PasswordHasher<string> passwordHasher;

        [BindProperty]
        public string Email { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public int PhoneNumber { get; set; }
        [BindProperty]
        public bool WishToSell { get; set; }
        [BindProperty]
        public string Type { get; set; }
        [BindProperty]
        public UserType UserType { get; set; }


        /// <summary>
        /// A constructor which initializes the user service.
        /// </summary>
        /// <param name="userService"></param>
        public CreateUserModel(UserService userService)
        {
            _userService = userService;
            passwordHasher = new PasswordHasher<string>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// A method which checks if the binding properties are correct 
        /// else it returns to the page. It then adds the customer to the userservice 
        /// and redirects to the index page.
        /// </summary>
        /// <returns>
        /// Returns the same page with an error message if the model state is invalid.
        /// Returns the index page if the model state is valid.
        /// </returns>
        public IActionResult OnPost()
        {


            if (UserType == Models.User.UserType.Customer)
            {
                ModelState.Remove(nameof(Type));
            }
            else if (UserType == Models.User.UserType.Employee)
            {
                ModelState.Remove(nameof(PhoneNumber));
                ModelState.Remove(nameof(WishToSell));
            }



            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UserType == Models.User.UserType.Customer) 
            {
                _userService.AddUser(new Customer(Id, FirstName, LastName, PhoneNumber, Email, passwordHasher.HashPassword(null, Password), WishToSell));
            }
            else if (UserType == Models.User.UserType.Employee)
            {
                _userService.AddUser(new Employee(Id, FirstName, LastName, Type, Email, passwordHasher.HashPassword(null, Password)));
            }

            return RedirectToPage("/Users/Admin/GetAllUsers");
        }
    }
}
