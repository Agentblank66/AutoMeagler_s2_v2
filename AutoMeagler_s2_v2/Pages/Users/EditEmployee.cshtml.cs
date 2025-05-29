using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Users
{
    [Authorize(Roles = "Employee")]
    public class EditEmployeeModel : PageModel
    {
        private UserService _userService;

        public EditEmployeeModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Models.Employee Employee { get; set; }

        public IActionResult OnGet(int id, User.UserType userType)
        {
            var user = _userService.GetUser(id, userType);
            if (user is Employee employee)
            {
                Employee = employee;
            }

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.UpdateUser(Employee);
            return RedirectToPage("/Users/Admin/GetAllUsers");
        }
    }
}
