using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IAdminService _adminService;
        public IndexModel(IAdminService adminService) => _adminService = adminService;

        public List<Item> Items { get; set; }

        public void OnGet()
        {
            Items = _adminService.GetAllItems();
        }
    }
}
