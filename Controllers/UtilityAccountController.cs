using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMgtSystem.Models;
using RentalMgtSystem.Services;
using System.Collections;

namespace RentalMgtSystem.Controllers
{
    public class UtilityAccountController : Controller
    {
        private readonly AppDBContext _dbContext;
        private readonly IDropdownService _dropdownService;
        public UtilityAccountController(AppDBContext dBContext, IDropdownService dropdownService)
        {
            _dbContext=dBContext;
            _dropdownService = dropdownService;
        }

        // GET: UtilityAccountController
  /*      public IEnumerable<SelectListItem> GetUnits()
        {
            var units = _dbContext.Unit
                .Select(u => new SelectListItem
                {
                    Value = u.UnitID.ToString(),//check this
                    Text = u.UnitName

                })
                .ToList();//fetch list of units
            return units;
        }*/
       
        public ActionResult Index()
        {
            //var accounts = _dbContext.UtilityAccount.ToList();
            /*  var accounts = _dbContext.UtilityAccount
                            .Include(u=>u.Unit)
                            .Select(ua=> new UtilityAccount
                            { 
                                UtilityAccountID=ua.UtilityAccountID,
                                UtilityAccountNo=ua.UtilityAccountNo,
                                UnitName=ua.Unit.UnitName,
                                UtilityType=ua.UtilityType })
                            .ToList();*/
            var accounts = (from account in _dbContext.UtilityAccount
                       join unit in _dbContext.Unit
                       on account.UnitID equals unit.UnitID
                       select new UtilityAccount
                       {
                           UtilityAccountID = account.UtilityAccountID,
                           UtilityAccountNo = account.UtilityAccountNo,
                           Unit = unit,
                           UtilityType = account.UtilityType
                       }).ToList();
            return View(accounts);
        }

        // GET: UtilityAccountController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["Units"] = await _dropdownService.GetUnitsAsync();
            return View();
        }

        // POST: UtilityAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UtilityAccount uaccount)
        {
            try
            {
                _dbContext.Add(uaccount);
                _dbContext.SaveChanges();
                TempData["Message"] = "Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilityAccountController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            ViewData["Units"] = await _dropdownService.GetUnitsAsync();
            var uaccount = _dbContext.UtilityAccount.Find(id);
            return View(uaccount);
        }

        // POST: UtilityAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("UtilityAccount/Edit/{id}")]
        public ActionResult Edit(int id, UtilityAccount uaccount)
        {
            try
            {
                _dbContext.Update(uaccount);
                _dbContext.SaveChanges(true);
                TempData["Message"] = "Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilityAccountController/Delete/5
      /*  public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: UtilityAccountController/Delete/5
        [Route("UtilityAccount/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var uaccount = await _dbContext.UtilityAccount.FindAsync(id);
                if (uaccount == null)
                {
                    return NotFound();
                }
                _dbContext.Remove(uaccount);
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
