using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;

namespace CMS.Pages.Admin.ManageCategories
{
    public class CreateModel : PageModel
    {
        private readonly IAdminService _adminService;

        public CreateModel(IAdminService adminService) => _adminService = adminService;

        [BindProperty]
        public Category Category { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _adminService.InsertCategory(Category);
            _adminService.Save();

            return RedirectToPage("./Index");
        }
    }
}
