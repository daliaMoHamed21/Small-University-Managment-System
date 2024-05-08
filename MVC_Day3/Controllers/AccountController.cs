using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MVC_Day3.Controllers
{
    public class AccountController : Controller
    {
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Login(string username)
        {
            // Check if username is null or empty
            if (string.IsNullOrEmpty(username) || username.Length < 3)
            {
                return View();
            }

            
            Claim c1 = new Claim(ClaimTypes.Name, username);
            Claim c2 = new Claim(ClaimTypes.Email, username + "@gmail.com");
            Claim c3 = new Claim(ClaimTypes.Role, "Admin");
            ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            ci.AddClaim(c1);
            ci.AddClaim(c2);
            ci.AddClaim(c3);

            ClaimsPrincipal cp = new ClaimsPrincipal(ci);
            await HttpContext.SignInAsync(cp);
            return RedirectToAction("Index", "Home");
        }

    }
}
