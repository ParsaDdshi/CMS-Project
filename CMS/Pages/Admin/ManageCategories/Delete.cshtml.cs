using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;

namespace CMS.Pages.Admin.ManageCategories
{
    public class DeleteModel : PageModel
    {
        private readonly IAdminService _adminService;

        public DeleteModel(IAdminService adminService) => _adminService = adminService;

        [BindProperty]
      public Category Category { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            Category = _adminService.GetCategoryById(id.Value);

            if (Category == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
                return NotFound();

            Category = _adminService.GetCategoryById(id.Value);

            if (Category != null)
            {
                _adminService.DeletCategoriesFromCategoryToItems(Category.CategoryId);
                _adminService.RemoveCategory(Category);
                _adminService.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
