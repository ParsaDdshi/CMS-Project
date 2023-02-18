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

namespace CMS.Pages.Admin.ManageUsers
{
    public class DeleteModel : PageModel
    {
        private readonly IAdminService _adminService;

        public DeleteModel(IAdminService adminService) => _adminService = adminService;

        [BindProperty]
        public User User { get; set; } = default!;
        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            User = _adminService.GetUserById(id.Value);
            if (User == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
                return NotFound();

            User = _adminService.GetUserById(id.Value);

            if (User != null)
            {
                _adminService.RemoveUserFavItems(User.UserId);
                _adminService.RemoveUser(User);
                _adminService.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
