﻿using ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration() => View("Registration");

        public IActionResult AdsMap() => View("AdsMap");

        public async Task<IActionResult> SendRegistrate(User user)
        {
            using var httpClient = new HttpClient();
            using var result = await httpClient.PostAsJsonAsync("https://localhost:7165/api/user/Registration", user);

            ViewBag.Result = result.StatusCode == System.Net.HttpStatusCode.OK ? "Регистрация прошла успешно"
                : "Во время регистрации возникли ошибки";

            return View("Registration");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}