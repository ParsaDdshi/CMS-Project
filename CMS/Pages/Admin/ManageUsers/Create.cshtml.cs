using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CMS.Models;
using CMS.Services.Interfaces;
using CMS.Services;

namespace CMS.Pages.Admin.ManageUsers
{
    public class CreateModel : PageModel
    {
        private readonly IAdminService _adminService;

        public CreateModel(IAdminService adminService) => _adminService = adminService;

        public IActionResult OnGet() => Page();
        
        [BindProperty]
        public User User { get; set; } = default!;
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          User.RegisterDate = DateTime.Now;
          if (!ModelState.IsValid)
            return Page();

          _adminService.AddUser(User);
          _adminService.Save();

            return RedirectToPage("./Index");
        }
    }
}
