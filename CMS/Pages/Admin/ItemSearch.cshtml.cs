using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin
{
    public class ItemSearchModel : PageModel
    {
        private readonly IAdminService _adminService;
        public ItemSearchModel(IAdminService adminService) => _adminService = adminService;

        public List<Item> Items { get; set; }
        public IActionResult OnPost(string search)
        {
            if(search == null)
                return RedirectToPage("Index");

            Items = _adminService.ItemSearch(search);

            if(Items == null)
                return NotFound();

            return Page();
        }
    }
}
