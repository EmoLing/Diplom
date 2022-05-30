using Helper.Users.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClientApp.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Login(UserViewModel user)
        {
            ViewBag.Result = String.Empty;

            using var httpClient = new HttpClient();
            var result = await httpClient
                .GetFromJsonAsync<Guid>
                ($"https://localhost:7165/api/user/Login/{user.Login}&{user.Password}", 
                CancellationToken.None);

            if (result == Guid.Empty)
            {
                ViewBag.Result = "Во время регистрации возникли ошибки";
                return View("Login");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login), 
                new Claim("Guid", result.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Redirect("/index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/index");
        }

        public async Task<IActionResult> SendRegistrate(RegistrateUserViewModel registrateUser)
        {
            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("https://localhost:7165/api/user/Registration", registrateUser);

            ViewBag.StatusCode = result.StatusCode;

            return View("Registration");
        }
    }
}
