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
    public class DetailsModel : PageModel
    {
        private readonly IAdminService _adminService;

        public DetailsModel(IAdminService adminService) => _adminService = adminService;

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
    }
}
