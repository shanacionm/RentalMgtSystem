using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentalMgtSystem.Controllers
{
    public class UtilityAccountController : Controller
    {
        // GET: UtilityAccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UtilityAccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilityAccountController/Create
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

        // GET: UtilityAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UtilityAccountController/Edit/5
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

        // GET: UtilityAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UtilityAccountController/Delete/5
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
