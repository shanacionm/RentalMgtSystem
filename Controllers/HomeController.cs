using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var units = await _dBContext.Unit.ToListAsync();
            return View(units);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
