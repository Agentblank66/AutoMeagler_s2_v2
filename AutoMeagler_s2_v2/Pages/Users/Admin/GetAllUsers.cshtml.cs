using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Admin
{
    /// <summary>
    /// This class is used to get all users from the database, where only Employees can go to the page.
    /// </summary>
    [Authorize(Roles = "Employee")]
    public class GetAllUsersModel : PageModel
    {
        /// <summary>
        /// Property of the GetAllUsersModel class.
        /// </summary>
        public UserService UserService { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        public List<User> FilteredUsers { get; set; } = new();
       


        /// <summary>
        /// Constructor of the GetAllUsersModel class.
        /// </summary>
        /// <param name="userService"></param>
        public GetAllUsersModel(UserService userService)
        {
            UserService = userService;
        }

        public void OnGet()
        {
               
        }

        public IActionResult OnPost()
        {

            if (string.IsNullOrWhiteSpace(SearchString))
            {
                return RedirectToPage("/NotFound");
            }

            FilteredUsers = UserService.SearchbyName(SearchString);

            if (FilteredUsers == null || !FilteredUsers.Any())
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }
    }
}
