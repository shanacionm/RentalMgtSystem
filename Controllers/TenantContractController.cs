using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMgtSystem.Models;
using RentalMgtSystem.Models.Dto;

namespace RentalMgtSystem.Controllers
{

    public class TenantContractController : Controller
    {
        // GET: TenantContractController
        private readonly AppDBContext _dbContext;
        public TenantContractController(AppDBContext dbContext)
        { 
            _dbContext = dbContext;
            
        }
        public void Reset()
        {
            var units = _dbContext.Unit
                .Select(u => new SelectListItem
                {
                    Value = u.UnitID.ToString(),//check this
                    Text = u.UnitName

                })
                .ToList();//fetch list of units
            ViewData["Units"] = units; //pass data for dropdown in view
            TempData["Message"] = "";
        }

        
        public async Task<ActionResult> Index()
        {
            var tenants=await _dbContext.TenantContract.ToListAsync();
            return View(tenants);
        }

        // GET: TenantContractController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            TempData["Message"] = "";
            var contract = _dbContext.TenantContract.Find(id);
            if (contract == null)                
                return NotFound();

            return PartialView("_View", contract);

        }

        // GET: TenantContractController/Create
        public ActionResult Create()
        {
            Reset();//fetch list of units
           
            var model=new TenantContractDto();
            return View(model);
        }

        // POST: TenantContractController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TenantContractDto newContract)
        {
            try
            {
                TenantContract tenantContract = new TenantContract
                {

                    TenantName=(String.IsNullOrEmpty(newContract.TenantName)?"-": newContract.TenantName),
                    RentalAmount=newContract.RentalAmount,
                    UnitName=newContract.UnitName,
                    Details=newContract.Details,
                    StartDate=newContract.StartDate,
                    EndDate=newContract.EndDate,
                    DownpaymentDate=newContract.DownpaymentDate,
                    ElectricityBased=newContract.ElectricityBased
                };

                _dbContext.TenantContract.Add(tenantContract);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Successfully Added";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TenantContractController/Edit/5
        public ActionResult Edit(int id)
        {
            Reset();
            var contract=_dbContext.TenantContract.Find(id);
            var model = new TenantContractDto
            {
                TenantName = contract.TenantName,
                RentalAmount = contract.RentalAmount,
                UnitName =  contract.UnitName,
                Details = contract.Details,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                DownpaymentDate = contract.DownpaymentDate,
                ElectricityBased = contract.ElectricityBased
            };
            

            return View(model);
        }

        // POST: TenantContractController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("TenantContract/Edit/{id}")]
        public async Task<ActionResult> Edit(int id, TenantContractDto contract)
        {
            try
            {
                var model = new TenantContract
                {
                    ContractID = id,
                    TenantName = contract.TenantName,
                    RentalAmount = contract.RentalAmount,
                    UnitName = contract.UnitName,
                    Details = contract.Details,
                    StartDate = contract.StartDate,
                    EndDate = contract.EndDate,
                    ElectricityBased = contract.ElectricityBased
                };
                _dbContext.Update(model);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TenantContractController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TenantContractController/Delete/5
               
        [Route("TenantContract/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var contract = await _dbContext.TenantContract.FindAsync(id);
                if (contract==null)
                {
                    return NotFound();
                }
                _dbContext.Remove(contract);
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
