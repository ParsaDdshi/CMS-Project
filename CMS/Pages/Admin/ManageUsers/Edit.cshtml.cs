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

namespace CMS.Pages.Admin.ManageUsers
{
    public class EditModel : PageModel
    {
        private readonly IAdminService _adminService;

        public EditModel(IAdminService adminService) => _adminService = adminService;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            User user = _adminService.GetUserById(User.UserId);
            user.UserName = User.UserName;
            user.Email = User.Email;
            user.Password = User.Password;

            try
            {
              _adminService.Save();
            }      
            catch (DbUpdateConcurrencyException)
            {
                if (!_adminService.IsUserExist(User.UserId))
                    return NotFound();
                else
                    throw;   
            }

            return RedirectToPage("./Index");
        }
    }
}
