using DynamicFieldsApp.Helpers;
using DynamicFieldsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace DynamicFieldsApp.Controllers
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
            try
            {
                var json = FileHelper.GetTextFromFileAsync("fields.json").Result;
                var fields = JsonHelper.GetFieldsFromJsonAsync(json).Result;
                ViewBag.Result = fields;
            }
            catch(Exception e)
            {
                ViewBag.Exception = e;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
