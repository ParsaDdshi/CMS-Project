using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin.ManageUsers
{
    public class ShowUsersByRoleModel : PageModel
    {
        private readonly IAdminService _adminService;

        public ShowUsersByRoleModel(IAdminService adminService) => _adminService = adminService;

        public IList<User> User { get; set; } = default!;
        public void OnGet(bool isAdmin, string role)
        {
            User = _adminService.GetUsersByRole(isAdmin);
            ViewData["Role"] = role;
        }
    }
}
