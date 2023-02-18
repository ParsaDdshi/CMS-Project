using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IAdminService _adminService;
        public DeleteModel(IAdminService adminService) => _adminService = adminService;

        [BindProperty]
        public AdminItemViewModel ItemViewModel { get; set; }

        [BindProperty]
        public List<int> ItemCategories { get; set; }

        public IActionResult OnGet(int itemId)
        {
            ItemViewModel = _adminService.GetItemViewModelById(itemId);

            if (ItemViewModel == null)
                return NotFound();

            ItemViewModel.Categories = _adminService.GetAllCategories();
            ItemCategories = _adminService.GetItemCategoryId(itemId);
            ViewData["ItemId"] = ItemViewModel.ItemId;

            return Page();
        }

        public IActionResult OnPost(int itemId)
        {
            _adminService.RemoveItem(itemId);
            _adminService.DeleteCategoryToItems(itemId);
            _adminService.Save();

            return RedirectToPage("Index");
        }
    }
}
