using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalMgtSystem.Models;
using RentalMgtSystem.Models.Dto;
using PagedList;
using PagedList.Mvc;
using RentalMgtSystem.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentalMgtSystem.Controllers
{
    public class UtilityController : Controller
    {

        private readonly AppDBContext _dbContext;
        private string sOrder;
        private readonly IDropdownService _dropdownService;
        public UtilityController(AppDBContext dBContext, IDropdownService dropdownService)
        {
            _dbContext = dBContext;
            _dropdownService = dropdownService;
        }
        public void Reset()
        {
            TempData["Message"] = "";
        }

        // GET: UtilityController
        public async Task<ActionResult> Index(string? sortOrder, string sortDir)
        {
           ViewBag.SortOptions = new SelectList(
           new List<SelectListItem>
           {
                new SelectListItem { Text = "Utility Type", Value = "UtilityType" },
                new SelectListItem { Text = "Billing Date", Value = "BillingDate" },
                new SelectListItem { Text = "Billing Amount", Value = "BillingAmount" }
           }, "Value", "Text", sortOrder);
            ViewBag.SortDir = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem{Text="Asc", Value="asc"},
                    new SelectListItem{Text="Desc", Value="desc"}
                }, "Value", "Text", sortDir);

            var utility =from u in _dbContext.Utility
                         select u;
                        /*= (from u in _dbContext.Utility
                           join ua in _dbContext.UtilityAccount
                           on u.UtilityAccountNo equals ua.UtilityAccountNo
                           select new Utility
                           {
                               UtilityID=u.UtilityID,
                              
                               BillingDate=u.BillingDate,
                               UtilityAccountNo
                           }
                           )*/

           

            //Sorting Logic           
            switch (sortOrder)
            {
                
                case "UtilityType":
                    utility = (sortDir == "desc") ?  utility.OrderByDescending(i => i.UtilityType): utility.OrderBy(i => i.UtilityType);
                    break;
               
                case "BillingDate":
                    utility = (sortDir == "desc") ? utility.OrderByDescending(i => i.BillingDate) : utility.OrderBy(i => i.BillingDate);
                    break;
                               
                case "BillingAmount":
                    utility = (sortDir == "desc") ? utility.OrderByDescending(i => i.BillingAmount) : utility.OrderBy(i => i.BillingAmount);
                    break;
                

                default:
                    utility = utility.OrderBy(i => i.UtilityID);
                    break;
            }         
            

            return View(await utility.ToListAsync());
        }

        // GET: UtilityController/Create       
        public async Task< ActionResult> Create()
        {
            Reset();
            ViewData["UtilityAccount"] = await _dropdownService.GetUtilityAccountAsync();
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
                    UtilityAccountNo=newUtility.UtilityAccountNo,
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
            ViewData["UtilityAccount"] = await _dropdownService.GetUtilityAccountAsync();
            var model = await _dbContext.Utility.FindAsync(id);
            return View(model);
        }

        // POST: UtilityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Utility/Edit/{id}")]
        public async Task<ActionResult> Edit(int id, [Bind("UtilityID","UtilityType", "UtilityAccountNo","BillingDate", "BillingAmount", "MainMeterReading", "SubmeterReading", "PaymentDate")] Utility utility)
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
