using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static AutoMeagler_s2_v2.Models.User;

namespace AutoMeagler_s2_v2.Users
{
    [Authorize(Roles = "Employee")]
    public class EditUserModel : PageModel
    {
        /// <summary>
        /// Properties of the EditUserModel class.
        /// </summary>
        private UserService _userService;
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string? Type { get; set; }
        [BindProperty]
        public int PhoneNumber { get; set; }
        
        public bool WishToSell { get; set; }
        [BindProperty]
        public UserType? UserType { get; set; }

        /// <summary>
        /// Constructor of the EditUserModel class.
        /// </summary>
        /// <param name="userService"></param>
        public EditUserModel(UserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// A method which is called when the page is loaded. If user is null, it redirects to the page with a message. 
        /// If checks if the user is a Customer or an Employee.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userType"></param>
        /// <returns>
        /// Returns a page with the user information if the user is found, or redirects if the user is not found.
        /// </returns>
        public IActionResult OnGet(int id, UserType userType)
        {
            var user = _userService.GetUser(id, userType);
            if (user == null)
                return RedirectToPage("/NotFound");

            UserType = user.UserTypes;
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            if (user is Customer customer)
            {
                PhoneNumber = customer.PhoneNumber;
            }
            else if (user is Employee employee)
            {
                Type = employee.Type;
            }

            return Page();
        }

        /// <summary>
        /// A method which first, removes the validation for the Type property if the user is a customer. 
        /// Then checks if the model state is valid. Then checks if it is a customer or an employee, and then updates that user.
        /// </summary>
        /// <returns>
        /// Returns the same page with an error message if the model state is invalid, else returns to the GetAllUsers page.
        /// </returns>
        public IActionResult OnPost(User user)
        {
           

            if (!ModelState.IsValid)
            {
                return Page();
            }

            User updatedUser = null;
            if (UserType == Models.User.UserType.Customer)
            {
                updatedUser = new Customer(Id, FirstName, LastName, PhoneNumber, Email, Password, WishToSell);
                updatedUser.UserTypes = (UserType)UserType;

            }
            else if (UserType == Models.User.UserType.Employee)
            {
                updatedUser = new Employee(Id, FirstName, LastName, Type, Email, Password);
                updatedUser.UserTypes = (UserType)UserType;


            }
            _userService.UpdateUser(updatedUser);
            return RedirectToPage("/Users/Admin/GetAllUsers");
        }
    }
}
