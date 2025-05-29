using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Users.Admin
{
    [Authorize(Roles = "Employee")]
    public class CreateCustomerModel : PageModel
    {
        public UserService _userService;
        private readonly PasswordHasher<string> _hasher;

        [BindProperty]
        public Models.Customer Customer { get; set; }

        public CreateCustomerModel(UserService userService)
        {
            _userService = userService;
            _hasher = new PasswordHasher<string>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer.Password = _hasher.HashPassword(Customer.Email, Customer.Password);
            _userService.AddUser(Customer);
            return RedirectToPage("/Users/Admin/GetAllUsers");
        }

    }
}
