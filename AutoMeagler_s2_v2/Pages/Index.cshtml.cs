using AutoMeagler_s2_v2.Pages.LogIn;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AutoMeagler_s2_v2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
           //{
            //    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //}
            //else if(LogInPageModel.LoggedInEmployee == null)
            //{
            //    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //}
        }
    }
}