using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalMgtSystem.Models;

namespace RentalMgtSystem.Controllers
{
    public class UtilityController : Controller
    {
        /*Notes TODOlist:
    * Dto 
    * Create
    *Edit 
    *Delete
    **/
        private readonly AppDBContext _dbContext;
        public UtilityController(AppDBContext dBContext)
        { 
            _dbContext = dBContext;
        }
        // GET: UtilityController
        public ActionResult Index()
        {
            var utility = _dbContext.Utility.ToList();
            return View(utility);
        }

        // GET: UtilityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UtilityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UtilityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UtilityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
