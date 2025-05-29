using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Users
{
    [Authorize(Roles = "Employee")]
    public class DeleteUserModel : PageModel
    {
        /// <summary>
        /// Property of the DeleteUserModel class.
        /// </summary>
        private UserService _userService;

        /// <summary>
        /// Constructor of the DeleteUserModel class.
        /// </summary>
        /// <param name="userService"></param>
        public DeleteUserModel(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// A method which is called when the page is loaded. If user is null, it redirects to the page with a message.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userType"></param>
        /// <returns>
        /// A page.
        /// </returns>
        public IActionResult OnGet(int id, User.UserType userType)
        {

            var user = _userService.GetUser(id, userType);
            if (user == null)
                return RedirectToPage("/NotFound");


            return Page();
        }

        /// <summary>
        /// A method which is called when the page is posted, where it deletes a user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userType"></param>
        /// <returns>
        /// Returns to the page with a message if the model state is invalid, else it returns to the GetAllUsers page.
        /// </returns>
        public IActionResult OnPost(int id, User.UserType userType)
        {
            var user = _userService.GetUser(id, userType);
            if (user == null)
            {
                return RedirectToPage("/NotFound");
            }
            else
            {
                _userService.DeleteUser(user);
            }
            //if (user is Customer customer)
            //    _userService.DeleteUser(customer);
            //else if (user is Employee employee)
            //    _userService.DeleteUser(employee);


            return RedirectToPage("/Users/Admin/GetAllUsers");
        }
    }
}
