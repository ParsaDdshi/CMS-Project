using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin
{
    public class ShowItemsByCategoryModel : PageModel
    {
        private readonly IAdminService _adminService;
        public ShowItemsByCategoryModel(IAdminService adminService) => _adminService = adminService;

        public List<Item> CategoryItems { get; set; }
        public void OnGet(int categoryId, string categoryName)
        {
            ViewData["CategoryName"] = categoryName;
            CategoryItems = _adminService.GetCategoryItems(categoryId);
        }
    }
}
