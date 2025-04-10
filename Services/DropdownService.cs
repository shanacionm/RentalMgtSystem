using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMgtSystem.Models;

namespace RentalMgtSystem.Services
{
    public class DropdownService: IDropdownService
    {
        private readonly AppDBContext _dbContext;
        public DropdownService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SelectListItem>> GetUnitsAsync()
        {
            return await _dbContext.Unit
               .Select(u => new SelectListItem
               {
                   Value = u.UnitID.ToString(),//check this
                   Text = u.UnitName

               })
               .ToListAsync();//fetch list of units
           
        }
        public async Task<IEnumerable<SelectListItem>> GetUtilityAccountAsync()
        {
            return await _dbContext.UtilityAccount
               .Select(u => new SelectListItem
               {
                   Value = u.UtilityAccountNo.ToString(),//check this
                   Text = u.UtilityAccountNo

               })
               .ToListAsync();//fetch list of units

        }
        public async Task<IEnumerable<SelectListItem>> GetTenantContractAsync()
        {
            return await _dbContext.TenantContract
                .Select(t => new SelectListItem
                {
                    Value = t.ContractID.ToString(),
                    Text = t.TenantName
                })
                .ToListAsync();
        }

    }
}
