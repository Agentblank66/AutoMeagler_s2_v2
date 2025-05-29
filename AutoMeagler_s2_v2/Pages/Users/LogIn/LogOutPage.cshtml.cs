using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.LogIn
{ 
    public class LogOutPageModel : PageModel
    {
        /// <summary>
        /// A method which signs out either the customer or the employee.
        /// </summary>
        /// <returns>
        /// Redirects to the index page.
        /// </returns>
        public async Task<IActionResult> OnGet()
        {
            //LogInPageModel.LoggedInCustomer = null;
            //LogInPageModel.LoggedInEmployee = null;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }

    }
}
