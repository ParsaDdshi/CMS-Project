using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IAdminService _adminService;
        public EditModel(IAdminService adminService) => _adminService = adminService;

        [BindProperty]
        public AdminItemViewModel ItemViewModel { get; set; }

        [BindProperty]
        public List<int> SelectedGroups { get; set; }

        [BindProperty]
        public List<int> ItemCategories { get; set; }
        public IActionResult OnGet(int itemId)
        {
            ItemViewModel = _adminService.GetItemViewModelById(itemId);

            if (ItemViewModel == null)
                return NotFound();

            ItemViewModel.Categories = _adminService.GetAllCategories();
            ItemCategories = _adminService.GetItemCategoryId(itemId); 

            return Page();
        }

        public IActionResult OnPost(int itemId)
        {
            ItemViewModel.Categories = _adminService.GetAllCategories();
            ItemCategories = _adminService.GetItemCategoryId(itemId);
            if (!ModelState.IsValid)
                return Page();

            Item item = _adminService.GetItemById(itemId);

            if (item == null)
                return NotFound();

            item.Title = ItemViewModel.Title;
            item.Text = ItemViewModel.Text;

            _adminService.Save();


            if (ItemViewModel.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory()
                    , "wwwroot"
                    , "assets"
                    , "img", item.ItemId + ".jpg");

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    ItemViewModel.Picture.CopyTo(stream);
            }

            _adminService.DeleteCategoryToItems(itemId);
            _adminService.Save();
            if (SelectedGroups.Count > 0 && SelectedGroups.Any())
            {
                foreach (int group in SelectedGroups)
                {
                    _adminService.InsertCategoryToItem(new CategoryToItem()
                    {
                        CategoryId = group,
                        ItemId = item.ItemId
                    });
                    _adminService.Save();
                }
            }

            return RedirectToPage("Index");
        }
    }
}
