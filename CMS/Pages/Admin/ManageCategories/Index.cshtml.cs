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
    public class IndexModel : PageModel
    {
        private readonly IAdminService _adminService;

        public IndexModel(IAdminService adminService) => _adminService = adminService;

        public IList<Category> Category { get;set; } = default!;

        public void  OnGet() => Category = _adminService.GetAllCategories();
    }
}
