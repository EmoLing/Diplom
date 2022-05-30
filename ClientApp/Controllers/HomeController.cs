using ClientApp.Models;
using Helper.Ads.ViewModels;
using Helper.Images;
using Helper.Users.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Ads;
using Model.Ads.Animals;
using System.Diagnostics;
using System.Security.Claims;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _appEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index() => View();

        [HttpGet("index")]
        public IActionResult MainPage() => View("Index");

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration() => View("Registration");

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> AdsMap()
        {
            var ads = await GetRequest<List<Ad>>("https://localhost:7155/api/Ads");
            return View("AdsMap", ads);
        }
        public IActionResult LoginView() => View("Registration");

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> CreateAdView()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("/home/LoginView");

            using var httpClient = new HttpClient();

            var colorOfAnimals = await GetRequest<List<ColorOfAnimal>>("https://localhost:7094/api/Animal/colorofanimals");
            var kindOfAnimals = await GetRequest<List<KindOfAnimal>>("https://localhost:7094/api/Animal/kindofanimals");

            var adViewModel = new NewAdViewModel()
            {
                ColorOfAnimals = colorOfAnimals,
                KindOfAnimals = kindOfAnimals
            };

            return View("CreateAd", adViewModel);
        }

        public IActionResult AboutUs() => NotFound();
        public IActionResult Contacts() => NotFound();

        [Authorize]
        [HttpPost]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> CreateAd(AdViewModel adViewModel)
        {
            var guid = Guid.Parse(User.FindFirst("Guid").Value);

            adViewModel.UserGuid = guid;

            var image = new List<byte[]>();
            image.AddRange(ImageHelper.GetImageFromRequest($"{_appEnvironment.WebRootPath}/Files/", User.Identity.Name));

            adViewModel.Photo = image;
            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("https://localhost:7155/api/Ads/CreateAd", adViewModel);

            try
            {
                if (result.StatusCode is not System.Net.HttpStatusCode.OK)
                    return Problem(result.Content.ToString());

                return Redirect("/home/AdsMap");
            }
            finally
            {
                DeleteUserFiles();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveFiles([FromForm] IFormFileCollection formFiles)
        {
            formFiles = Request.Form.Files;
            if (!formFiles.Any())
                return Problem("Файл не загружен");

            for (int i = 0; i < formFiles.Count; i++)
            {
                var fileName = $"{User.Identity.Name}_{i}_{formFiles[i].FileName}";
                string path = $"{_appEnvironment.WebRootPath}/files/{fileName}";

                using var fileStream = new FileStream(path, FileMode.Create);
                await formFiles[i].CopyToAsync(fileStream);
            }

            return Ok();
        }

        private void DeleteUserFiles()
        {
            var dirInfo = new DirectoryInfo($"{_appEnvironment.WebRootPath}/files/");
            if (!dirInfo.Exists)
                return;

            var userFiles = dirInfo.GetFiles().Where(f => f.Name.Contains(User.Identity.Name));
            foreach (var file in userFiles)
                file.Delete();
        }

        public async Task<IActionResult> GetAds()
        {
            var ads = await GetRequest<List<Ad>>("https://localhost:7155/api/Ads");
            return View("AdsMap", ads);
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