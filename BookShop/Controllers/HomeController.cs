using BookShop.Models;
using Core.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookService _bookservice;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BookService bookservice)
        {
            _logger = logger;
            _bookservice = bookservice;
        }

        public async Task< IActionResult> Index()
        {
          
            return View();
        }
        [Authorize]
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
