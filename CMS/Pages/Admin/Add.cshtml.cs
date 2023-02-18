using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin
{
    public class AddModel : PageModel
    {
        private readonly IAdminService _adminService;
        public AddModel(IAdminService adminService) => _adminService = adminService;

        [BindProperty]
        public AdminItemViewModel ItemViewModel { get; set; }

        [BindProperty]
        public List<int> SelectedGroups { get; set; }
        public void OnGet()
        {
            ItemViewModel = new AdminItemViewModel()
            {
                Categories = _adminService.GetAllCategories()
            };
        }

        public IActionResult OnPost()
        {
            ItemViewModel.Categories = _adminService.GetAllCategories();

            if(!ModelState.IsValid) 
                return Page();

            Item item = new Item()
            {
                Title = ItemViewModel.Title,
                Text = ItemViewModel.Text,
                CreateDate = DateTime.Now,
                Views = 0
            };
            _adminService.InsertItem(item);
            _adminService.Save();

            if(ItemViewModel.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory()
                    , "wwwroot"
                    , "assets"
                    , "img", item.ItemId + ".jpg");

                using(FileStream stream = new FileStream(filePath, FileMode.Create))
                    ItemViewModel.Picture.CopyTo(stream);
            }
            else
            {
                ModelState.AddModelError("picture", "The picture field is required.");
                return Page();
            }

            if(SelectedGroups.Count > 0 && SelectedGroups.Any()) 
            {
                foreach(int group in SelectedGroups)
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
