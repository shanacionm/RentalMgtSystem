using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentalMgtSystem.Services
{
    public interface IDropdownService
    {
        Task<IEnumerable<SelectListItem>> GetUnitsAsync();
        Task<IEnumerable<SelectListItem>> GetUtilityAccountAsync();
    }
}
