using Microsoft.AspNetCore.Mvc;
using RentalMgtSystem.Models;
using System.Diagnostics;

namespace RentalMgtSystem.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _dBContext;

        public HomeController(ILogger<HomeController> logger, AppDBContext dbContext)
        {
            _dBContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var units = _dBContext.Unit.ToList();
            return View(units);
        }

        public IActionResult Privacy()
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
