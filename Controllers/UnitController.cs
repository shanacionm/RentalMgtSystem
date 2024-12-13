using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalMgtSystem.Models;

namespace RentalMgtSystem.Controllers
{
    public class UnitController : Controller
    {
        // GET: UnitController
        private readonly AppDBContext _dbContext;
        public UnitController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Reset()
        {
            TempData["Message"] = "";
        }
        public async Task <ActionResult> Index()
        {
            var units=await _dbContext.Unit.ToListAsync();
            return View(units);
        }

        // GET: UnitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnitController/Create
        public ActionResult Create()
        {
            Reset();
            return View();
        }

        // POST: UnitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Unit unit)
        {
            try
            {
                _dbContext.Add(unit);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
           

        // POST: UnitController/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Unit/Edit/{id}")]
        public async Task<ActionResult> Edit(int id, [Bind("UnitID,UnitName,Description")] Unit unit)
        {
            try
            {
                if(id!=unit.UnitID)
                {
                    return NotFound();
                }
                _dbContext.Update(unit);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: UnitController/Edit/5       
        public ActionResult Edit(int id)
        {
            Reset();
            var item = _dbContext.Unit.Find(id);
            return View(item);
        }

        // POST: UnitController/Delete/5
        [Route("Unit/Delete/{id}")]      
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var item = await _dbContext.Unit.FindAsync(id);
                if(item==null)
                {
                    return NotFound();
                }
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
