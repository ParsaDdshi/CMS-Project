using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin.ManageCategories
{
    public class CategorySearchModel : PageModel
    {
        private readonly IAdminService _adminService;

        public CategorySearchModel(IAdminService adminService) => _adminService = adminService;

        public IList<Category> Category { get; set; } = default!;
        public IActionResult OnPost(string search)
        {
            if (search == null)
                return RedirectToPage("Index");

            Category = _adminService.CategorySearch(search);

            return Page();
        }
    }
}
