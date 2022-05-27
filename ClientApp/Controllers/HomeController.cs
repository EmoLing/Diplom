using ClientApp.Models;
using Helper.Ads.ViewModels;
using Helper.Users.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();

        [HttpGet("index")]
        public IActionResult MainPage() => View("Index");

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration() => View("Registration");
        public IActionResult AdsMap() => View("AdsMap");
        public IActionResult LoginView() => View("Login");
        public IActionResult CreateAdView()
        {
            if (User.Identity.IsAuthenticated)
                return View("CreateAd");

            return Redirect("/home/LoginView");
        }

        public IActionResult AboutUs() => NotFound();
        public IActionResult Contacts() => NotFound();

        public async Task<IActionResult> SendRegistrate(RegistrateUserViewModel registrateUser)
        {
            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("https://localhost:7165/api/user/Registration", registrateUser);

            ViewBag.Result = result.StatusCode == System.Net.HttpStatusCode.OK ? "Регистрация прошла успешно"
                : "Во время регистрации возникли ошибки";

            return View("Registration");
        }

        #region Login/Logout

        public async Task<IActionResult> Login(UserViewModel user)
        {
            ViewBag.Result = String.Empty;

            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("https://localhost:7165/api/user/Login", user);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.Result = "Во время регистрации возникли ошибки";
                return View("Login");
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
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

        #endregion

        [Authorize]
        public async Task<IActionResult> CreateAd(CreateAdViewModel createAdViewModel)
        {
            string request = "https://localhost:7165/api/user/" +
                '{' + User.Identity.Name + '}';

            var guid = await GetRequest<Guid>(request);

            var adViewModel = (AdViewModel)createAdViewModel;
            adViewModel.UserGuid = guid;

            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("https://localhost:7155/api/Ads/CreateAd", adViewModel);

            if (result.StatusCode is not System.Net.HttpStatusCode.OK)
                return Problem(result.Content.ToString());

            return Redirect("/home/AdsMap");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<T> GetRequest<T>(string url)
        {
            using var httpClient = new HttpClient();
            var result = await httpClient
                .GetFromJsonAsync<T>(url, CancellationToken.None);

            return result;
        }
    }
}