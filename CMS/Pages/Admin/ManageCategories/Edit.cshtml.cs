using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;

namespace CMS.Pages.Admin.ManageCategories
{
    public class EditModel : PageModel
    {
        private readonly IAdminService _adminService;

        public EditModel(IAdminService adminService) => _adminService = adminService;

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Category = _adminService.GetCategoryById(id.Value);
            if (Category == null)
                return NotFound();
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();


            Category category = _adminService.GetCategoryById(Category.CategoryId);
            category.CategoryName = Category.CategoryName;

            try
            {
                _adminService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_adminService.IsCategoryExist(Category.CategoryId))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
