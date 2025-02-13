using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalMgtSystem.Models;
using RentalMgtSystem.Models.Dto;

namespace RentalMgtSystem.Controllers
{
    public class UtilityController : Controller
    {
        /*Notes TODOlist:
    * Dto -done
    * Create -done
    *Edit -done
    *Delete-done
    *async-done
    *paging
    *sort
    **/
        private readonly AppDBContext _dbContext;
        public UtilityController(AppDBContext dBContext)
        { 
            _dbContext = dBContext;
            
        }
        public void Reset()
        {
            TempData["Message"] = "";
        }
        // GET: UtilityController
        public async Task<ActionResult> Index()
        {
            var utility =await _dbContext.Utility.ToListAsync();
            return View(utility);
        }

        // GET: UtilityController/Create       
        public ActionResult Create()
        {
            Reset();
            var model = new UtilityDto();
            return View(model);
        }

        // POST: UtilityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UtilityDto newUtility)
        {
            try
            {
                Utility utility = new Utility
                {
                    UtilityType=newUtility.UtilityType,
                    BillingDate=newUtility.BillingDate,
                    BillingAmount=newUtility.BillingAmount,
                    MainMeterReading=newUtility.MainMeterReading,
                    SubmeterReading=newUtility.SubmeterReading,
                    PaymentDate=newUtility.PaymentDate                    
                };
                _dbContext.Add(utility);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilityController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Reset();
            var model = await _dbContext.Utility.FindAsync(id);
            return View(model);
        }

        // POST: UtilityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Utility/Edit/{id}")]
        public async Task<ActionResult> Edit(int id, [Bind("UtilityID","UtilityType", "BillingDate", "BillingAmount", "MainMeterReading", "SubmeterReading", "PaymentDate")] Utility utility)
        {
            try
            {
                if (id != utility.UtilityID)
                    return NotFound();
                _dbContext.Utility.Update(utility);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: UtilityController/Delete/5
        [Route("Utility/Delete/{id}")]
        public async Task <ActionResult> Delete(int id)
        {
            try
            {
                if(id==null||id==0)
                    return NotFound();
                var utility=await _dbContext.Utility.FindAsync(id);
                if (utility!=null)
                    _dbContext.Utility.Remove(utility);
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
